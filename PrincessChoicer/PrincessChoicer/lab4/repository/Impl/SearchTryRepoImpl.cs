using Microsoft.EntityFrameworkCore;
using PrincessChoicer.lab4.db.conf;
using PrincessChoicer.lab4.db.entity;

namespace PrincessChoicer.lab4.repository.Impl;

public class SearchTryRepoImpl : ISearchTryRepo
{
    private readonly EnvironmentContext _context;

    public SearchTryRepoImpl(EnvironmentContext context)
    {
        _context = context;
    }
    
    
    public SearchTry? GetSearchTryByName(string name)
    {
        var searchTry = _context.SearchTries.FirstOrDefault(searchLoveTry => searchLoveTry.Name == name);
        _context.Entry(searchTry)
            .Collection(search => search.Challengers)
            .Load();

        return searchTry;
    }

    public void SaveSearchTry(SearchTry searchLoveTry)
    {
        _context.SearchTries
            .Add(searchLoveTry);

        _context.SaveChanges();
    }

    public double GetAllSearchTriesAverageValue()
    {
        return _context.SearchTries
            .Average(search => search.SearchResult);
    }

    public void DeleteAllSearchTries()
    {
        foreach (var id in _context.SearchTries.Select(e => e.Id))
        {
            var searchTry = new SearchTry { Id = id };
            _context.SearchTries.Attach(searchTry);
            _context.SearchTries.Remove(searchTry);
        }

        _context.SaveChanges();
    }

    public List<SearchTry> GetAllSearchTries()
    {
        return _context.SearchTries
            .Include(search => search.Challengers)
            .ToList();
    }
}