using PrincessChoicer.utils;

namespace PrincessChoicer.model;

public static class ContentGenerator
{
    private const string NamesFilePath = "resources/names.txt";
    
    public static List<HusbandChallenger> GenerateChallengerList()
    {
        var ratings = GenerateRatings();
        var challengers = new List<HusbandChallenger>();
        var names = GenerateNames();
        {
            for (var i = 0; i < 100; i++)
            {
                challengers.Add(new HusbandChallenger(names[i], ratings[i]));
            }
        }

        return challengers;
    }

    private static List<int> GenerateRatings()
    {
        var ratings = new List<int>();
        for(var i = 0; i < 100; i++){
            ratings.Add(i + 1);
        }
        Shuffler.Shuffle(ref ratings);
        return ratings;
    }

    private static List<string> GenerateNames()
    {
        var namesArray = File.ReadAllLines(NamesFilePath);
        var names = new List<string>(namesArray);
        Shuffler.Shuffle(ref names);
        return names;
    }
}