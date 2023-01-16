namespace WorkerService1.model;

public class Hall
{
    
    private readonly List<HusbandChallenger> _challengerList;
    private int _husbandNumber;

    public Hall(List<HusbandChallenger> challengerList)
    {
        _challengerList = challengerList;
        _husbandNumber = 0;
        foreach (var challenger in _challengerList)
        {
            challenger.PrintInfo();
        }
    }

    public HusbandChallenger GetNextChallenger()
    {
        _husbandNumber++;
        return _challengerList[_husbandNumber - 1];
    }

    public int GetChallengerAmount()
    {
        return _challengerList.Count;
    }
}