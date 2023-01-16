using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using PrincessChoicer.common.model.impl;
using PrincessChoicer.lab4.db.conf;
using PrincessChoicer.lab4.repository.Impl;
using PrincessChoicer.lab4.service;
using PrincessChoicer.lab4.service.Impl;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrincessChoicerTest.lab4;

[TestFixture]
public class SimulationServiceTest
{
    
    private static readonly DbContextOptions<EnvironmentContext> ContextOptions =
        new DbContextOptionsBuilder<EnvironmentContext>()
            .UseInMemoryDatabase(databaseName: "princess-choicer")
            .Options;

    private readonly EnvironmentContext _context;
    private readonly ISearchSimulationService _searchSimulationService;
    private const int SearchesNumber = 25;
    private const string ConfigAppSettingsPath = "resources/application-properties.json";

    public SimulationServiceTest()
    {
        _context = new EnvironmentContext(ContextOptions);
        var hall = new HallImpl();
        _searchSimulationService = new SearchSimulationServiceImpl(
            new SearchTryServiceImpl(new SearchTryRepoImpl(_context)),
            hall,
            new PrincessImpl(new FriendImpl(), hall),
            new ContentGeneratorImpl(),
            new ConfigurationBuilder().AddJsonFile(ConfigAppSettingsPath).Build(),
            new Logger<SearchSimulationServiceImpl>(new LoggerFactory())
        );
    }

    [Test, Order(1)]
    public void SimulateSearchesSavedInDbOk()
    {
        var searchesBefore = _searchSimulationService.GetCurrentSearchStatus();
        
        _searchSimulationService.SimulateSearch(SearchesNumber);
        var searchesAfter = _searchSimulationService.GetCurrentSearchStatus();

        Assert.AreEqual(0, searchesBefore.Count);
        Assert.AreEqual(SearchesNumber, searchesAfter.Count);
    }

    [Test, Order(2)]
    public void ComparingSimulatingAndActualSearchesOk()
    {
        var searches = _searchSimulationService.GetCurrentSearchStatus();
        var resultsList = 
            (from search 
                in searches 
                let searchResult = _searchSimulationService.RerunSearchTryByName(search.Name, false) 
                select (search.SearchResult, searchResult))
            .ToList();

        resultsList.ForEach(result => Assert.AreEqual(result.Item1, result.Item2));
    }
    
    [Test, Order(3)]
    public void GetSearchAvgOk()
    {
        var searches = _searchSimulationService.GetCurrentSearchStatus();
        var expectedAvg = (from search in searches select search.SearchResult).Average();
        var actualAvg = _searchSimulationService.GetAverageSearchResultValue(false);
        
        Assert.AreEqual(expectedAvg, actualAvg);
    }

    [ClassCleanup]
    public void CleanContext()
    {
        _context.Database.EnsureDeleted();
    }
}