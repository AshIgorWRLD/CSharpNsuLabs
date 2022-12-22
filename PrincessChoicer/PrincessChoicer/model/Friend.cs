namespace PrincessChoicer.model;

public class Friend
{
    private int _maxRating;

    public Friend()
    {
        _maxRating = 0;
    }

    public bool IsBetter(HusbandChallenger challenger)
    {
        return challenger.Rating > _maxRating;
    }
    
    public void AddNewChallenger(HusbandChallenger challenger){
        if (IsBetter(challenger))
        {
            _maxRating = challenger.Rating;
        }
    }
}