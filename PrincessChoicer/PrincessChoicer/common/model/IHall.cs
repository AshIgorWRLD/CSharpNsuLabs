namespace PrincessChoicer.common.model;

public interface IHall
{
    void SetChallengerList(List<HusbandChallenger> challengerList);
    HusbandChallenger GetNextChallenger();
    int GetChallengerAmount();
    void Clear();
}