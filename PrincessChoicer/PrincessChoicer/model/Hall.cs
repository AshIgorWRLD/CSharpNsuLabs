using PrincessChoicer.utils;

namespace PrincessChoicer.model;

public class Hall
{
    private List<HusbandChallenger> _challengerList;
    private string namesFilePath = "C:/Users/Igor/GitHubResume/CSharpNsuLabs/PrincessChoicer/PrincessChoicer/model/names.txt";

    public Hall()
    {
        this._challengerList = getChallengers();
        for (var i = 0; i < _challengerList.Capacity; i++)
        {
            var str = _challengerList[i].Id.ToString() + ": " + _challengerList[i].Name + " " 
                + _challengerList[i].Rating;
            Console.WriteLine(str);
        }
    }
    
    public Hall(List<HusbandChallenger> challengerList)
    {
        this._challengerList = challengerList;
    }

    private List<HusbandChallenger> getChallengers()
    {
        var ratings = generateRatings();
        var challengers = new List<HusbandChallenger>();
        var names = generateNames();
        {
            for (var i = 0; i < 100; i++)
            {
                challengers.Add(new HusbandChallenger(names[i], ratings[i]));
            }
        }

        return challengers;
    }

    private List<int> generateRatings()
    {
        var ratings = new List<int>();
        for(var i = 0; i < 100; i++){
            ratings.Add(i + 1);
        }
        Shuffler.shuffle(ref ratings);
        return ratings;
    }

    private List<string> generateNames()
    {
        var namesArray = File.ReadAllLines(namesFilePath);
        var names = new List<string>(namesArray);
        Shuffler.shuffle(ref names);
        return names;
    }
} 