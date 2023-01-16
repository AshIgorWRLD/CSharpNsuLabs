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

    private List<HusbandChallenger> _visitedChallengers;


    public SearchSimulationServiceImpl(ISearchTryService searchTryService, IHall hall, IPrincess princess,
        IContentGenerator contentGenerator,IConfiguration configuration, ILogger<SearchSimulationServiceImpl> logger)
    {
        _searchTryService = searchTryService;
        _hall = hall;
        _princess = princess;
        _contentGenerator = contentGenerator;
        _logger = logger;
        _configuration = configuration;
        
        _visitedChallengers = new List<HusbandChallenger>();
    }

    public void SimulateSearch(int triesNumber)
    {
        _searchTryService.DeleteAllSearchTries();

        var particularFailTries = 0;
        var fullSuccessTries = 0;
        var fullFailureTries = 0;

        for (int i = 0; i < triesNumber; i++)
        {
            RefreshChallengerList();

            InitHall(CallType.Update, new SearchTry());

            var chosenVariant = _princess.Choose();
            var happinessLevel = ConvertToHappinessLvl(chosenVariant);
            
            _searchTryService
                .SaveSearchTry($"Try[{i}]", _visitedChallengers, happinessLevel);
        }
    }

    public int RerunSearchTryByName(string name, bool toPrint)
    {
        RefreshChallengerList();

        var searchTry = _searchTryService.GetSearchTryByName(name);
        if (searchTry == null)
        {
            _logger.LogInformation($"No search try with name: {name}.");
            return -1;
        }

        InitHall(CallType.Recall, searchTry);
        var chosenVariant = _princess.Choose();
        var happinessLevel = ConvertToHappinessLvl(chosenVariant);

        if (toPrint)
        {
            PrintResult(happinessLevel, name);
        }

        return happinessLevel;
    }

    public double GetAverageSearchResultValue(bool toPrint)
    {
        var averageValue = _searchTryService.GetAllSearchTriesAverageValue();
        
        if (toPrint)
        {
            PrintAverageValue(averageValue);
        }

        return averageValue;
    }

    public List<SearchTry> GetCurrentSearchStatus()
    {
        return _searchTryService.GetAllSearchTries();
    }

    private void InitHall(CallType callType, SearchTry searchTry)
    {
        if (callType == CallType.Update)
        {
            var challengerList = _contentGenerator.GenerateChallengerList();
            _visitedChallengers = challengerList;
            _hall.SetChallengerList(challengerList);
        }
        else if (callType == CallType.Recall)
        {
            var challengerList = searchTry.Challengers
                .Select(ce => new HusbandChallenger(ce.Name, ce.Rating))
                .ToList();
            _visitedChallengers = challengerList;
            _hall.SetChallengerList(challengerList);
        }
    }
    
    private void RefreshChallengerList()
    {
        _princess.FriendRefresh();
    }

    private static int ConvertToHappinessLvl(HusbandChallenger? husbandChallenger)
    {
        if (husbandChallenger == null)
        {
            return 10;
        }

        if (husbandChallenger.Rating < 50)
        {
            return 0;
        }

        return husbandChallenger.Rating;
    }
    
    private void PrintResult(int choiceResult, string tryName)
    {
        using StreamWriter file = new($"{tryName}.txt");
        for (int i = 0; i < _visitedChallengers.Count; i++)
        {
            file.WriteLineAsync($"{i + 1}: {_visitedChallengers[i].GetInfo()}");
        }

        file.WriteLineAsync("--------------------");
        file.WriteLineAsync($"Choice result: {choiceResult}");
    }
    
    private static void PrintAverageValue(double averageValue)
    {
        using StreamWriter file = new($"averageValue.txt");
        file.WriteLineAsync($"Average value: {averageValue}");
    }
}