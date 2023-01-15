using PrincessChoicer.lab4.db.entity;

namespace PrincessChoicer.lab4.repository;

public interface ISearchTryRepo
{
    SearchTry? GetSearchTryByName(string name);
    void SaveSearchTry(SearchTry searchLoveTry);
    double GetAllSearchTriesAverageValue();
    void DeleteAllSearchTries();
    public List<SearchTry> GetAllSearchTries();
}