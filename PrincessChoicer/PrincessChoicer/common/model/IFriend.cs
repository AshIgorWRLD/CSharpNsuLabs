namespace PrincessChoicer.common.model;

public interface IFriend
{
    bool IsBetter(HusbandChallenger challenger);
    void AddNewChallenger(HusbandChallenger challenger);
}