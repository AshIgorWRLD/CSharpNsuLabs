namespace PrincessChoicer.common.model;

public interface IPrincess
{
    void FriendRefresh();
    void UpdateHall(List<HusbandChallenger> challengers);
    string TellWhoIsHusband();
    HusbandChallenger? Choose();
    int GetPassChallengersAmount(int challengerAmount);
}