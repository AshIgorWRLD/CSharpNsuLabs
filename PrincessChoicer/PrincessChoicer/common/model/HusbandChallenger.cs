using System.Text;

namespace PrincessChoicer.common.model;

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

    public string GetInfo()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Name)
            .Append(" - ")
            .Append(Rating);
        return stringBuilder.ToString();
    }

    public string GetInfoWithId()
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Id)
            .Append(": ")
            .Append(Name)
            .Append(' ')
            .Append(Rating);
        return stringBuilder.ToString();
    }
}