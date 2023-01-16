namespace PrincessChoicer.common.model;

public interface IFriend
{
    void Refresh();
    bool IsBetter(HusbandChallenger challenger);
    void AddNewChallenger(HusbandChallenger challenger);
}