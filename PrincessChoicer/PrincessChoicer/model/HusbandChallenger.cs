using System.Text;

namespace PrincessChoicer.model;

public class HusbandChallenger
{
    public Guid Id { get; }
    public string Name { get; }
    public int Rating { get; }

    public HusbandChallenger(string name, int rating)
    {
        Id = Guid.NewGuid();
        Name = name;
        Rating = rating;
    }

    public void PrintInfo()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Id)
            .Append(": ")
            .Append(Name)
            .Append(' ')
            .Append(Rating);
        Console.WriteLine(stringBuilder);
    }
}