using PrincessChoicer.common.exception;

namespace PrincessChoicer.common.model.impl;

public class HallImpl : IHall
{
    private List<HusbandChallenger>? _challengerList;
    private int _husbandNumber;
    private int _husbandAmount;

    public HallImpl()
    {
        _husbandNumber = 0;
    }

    public void SetChallengerList(List<HusbandChallenger> challengerList)
    {
        _challengerList = challengerList;
        _husbandAmount = _challengerList.Count;
        _husbandNumber = 0;
    }

    public HusbandChallenger GetNextChallenger()
    {
        _husbandNumber++;
        if (_husbandNumber > _husbandAmount)
        {
            throw new CustomException(ErrorType.HallIsEmpty());
        }
        return _challengerList[_husbandNumber - 1];
    }

    public int GetChallengerAmount()
    {
        return _challengerList.Count;
    }

    public void Clear()
    {
        if (_challengerList == null)
        {
            return;
        }
        _challengerList.Clear();
    }
} 