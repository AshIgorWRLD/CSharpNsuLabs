namespace PrincessChoicer.lab4.db.entity;

public class Challenger
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int Rating { get; set; }
    public SearchTry SearchTry { get; set; }

    public Challenger(string name, int rating)
    {
        Name = name;
        Rating = rating;
    }
}