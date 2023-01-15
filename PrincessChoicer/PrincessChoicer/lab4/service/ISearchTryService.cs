using PrincessChoicer.common.model;
using PrincessChoicer.lab4.db.entity;

namespace PrincessChoicer.lab4.service;

public interface ISearchTryService
{
    SearchTry? GetSearchLoveTryByName(string name);
    void SaveSearchTry(string tryName, List<HusbandChallenger> challengers, int searchResult);
    void DeleteAllSearchTries();
    double GetAllSearchTriesAverageValue();
    public List<SearchTry> GetAllSearchTries();
}