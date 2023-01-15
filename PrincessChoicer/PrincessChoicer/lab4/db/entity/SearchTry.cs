namespace PrincessChoicer.lab4.db.entity;

public class SearchTry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int SearchResult { get; set; }

    public List<Challenger> Challengers { get; set; }

    public SearchTry()
    {
    }

    public SearchTry(string name, int searchResult, List<Challenger> challengers)
    {
        Name = name;
        SearchResult = searchResult;
        Challengers = challengers;
    }
}