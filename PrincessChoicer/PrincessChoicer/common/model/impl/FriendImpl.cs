namespace PrincessChoicer.common.model.impl;

public class FriendImpl : IFriend
{
    private int _maxRating;

    public FriendImpl()
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