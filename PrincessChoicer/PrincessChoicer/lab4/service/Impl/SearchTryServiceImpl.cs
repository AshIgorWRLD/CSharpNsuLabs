using PrincessChoicer.common.model;
using PrincessChoicer.lab4.db.entity;
using PrincessChoicer.lab4.repository;

namespace PrincessChoicer.lab4.service.Impl;

public class SearchTryServiceImpl : ISearchTryService
{
    private readonly ISearchTryRepo _searchTryRepo;

    public SearchTryServiceImpl(ISearchTryRepo searchTryRepo)
    {
        _searchTryRepo = searchTryRepo;
    }
    
    public SearchTry? GetSearchTryByName(string name)
    {
        return _searchTryRepo.GetSearchTryByName(name);
    }

    public void SaveSearchTry(string tryName, List<HusbandChallenger> challengers, int searchResult)
    {
        var challengerList = challengers
            .Select(challenger =>
                new Challenger(challenger.Name, challenger.Rating))
            .ToList();

        _searchTryRepo.SaveSearchTry(new SearchTry(tryName, searchResult, challengerList));
    }

    public void DeleteAllSearchTries()
    {
        _searchTryRepo.DeleteAllSearchTries();
    }

    public double GetAllSearchTriesAverageValue()
    {
        return _searchTryRepo.GetAllSearchTriesAverageValue();
    }

    public List<SearchTry> GetAllSearchTries()
    {
        return _searchTryRepo.GetAllSearchTries();
    }
}