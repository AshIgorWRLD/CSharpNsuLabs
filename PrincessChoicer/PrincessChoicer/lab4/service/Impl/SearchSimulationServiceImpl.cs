using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using PrincessChoicer.common.model;
using PrincessChoicer.lab4.db.entity;

namespace PrincessChoicer.lab4.service.Impl;

public class SearchSimulationServiceImpl : ISearchSimulationService
{
    
    private readonly ISearchTryService _searchTryService;
    private readonly IHall _hall;
    private readonly IPrincess _princess;
    private readonly IContentGenerator _contentGenerator;
    private readonly ILogger<SearchSimulationServiceImpl> _logger;
    private readonly IConfiguration _configuration;

    private readonly int _startContendersNumber;
    private readonly List<HusbandChallenger> _visitedChallengers;


    public SearchSimulationServiceImpl(ISearchTryService searchTryService, IHall hall, IPrincess princess,
        IContentGenerator contentGenerator, ILogger<SearchSimulationServiceImpl> logger, IConfiguration configuration,
        List<HusbandChallenger> visitedChallengers)
    {
        _searchTryService = searchTryService;
        _hall = hall;
        _princess = princess;
        _contentGenerator = contentGenerator;
        _logger = logger;
        _configuration = configuration;
        
        _startContendersNumber = configuration.GetValue<int>("SearchParams:DefaultStartChallengersNumber");
        _visitedChallengers = visitedChallengers;
    }

    public void SimulateSearch(int triesNumber)
    {
        throw new NotImplementedException();
    }

    public int RerunSearchTryByName(string name, bool toPrint)
    {
        throw new NotImplementedException();
    }

    public double GetAverageSearchResultValue(bool toPrint)
    {
        throw new NotImplementedException();
    }
}