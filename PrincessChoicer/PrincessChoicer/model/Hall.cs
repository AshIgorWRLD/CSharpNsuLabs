using PrincessChoicer.utils;

namespace PrincessChoicer.model;

public class Hall
{
    private List<HusbandChallenger> challengerList;

    public Hall()
    {
        this.challengerList = getChallengers();
        for (int i = 0; i < challengerList.Capacity; i++)
        {
            String str = challengerList[i].Id.ToString() + ": " + challengerList[i].Rating;
            Console.WriteLine(str);
        }
    }
    
    public Hall(List<HusbandChallenger> challengerList)
    {
        this.challengerList = challengerList;
    }

    private List<HusbandChallenger> getChallengers()
    {
        var ratings = generateRatings();
        var challengers = new List<HusbandChallenger>();
        for (int i = 0; i < 100; i++)
        {
            challengers.Add(new HusbandChallenger(ratings[i]));
        }
        return challengers;
    }

    private List<int> generateRatings()
    {
        var ratings = new List<int>();
        for(int i = 0; i < 100; i++){
            ratings.Add(i + 1);
        }
        Shuffler.shuffle(ref ratings);
        return ratings;
    }
    
} 