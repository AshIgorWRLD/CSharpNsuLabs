using System.Text;
using PrincessChoicer.common.exception;
using PrincessChoicer.common.utils;

namespace PrincessChoicer.common.model.impl;

public class PrincessImpl : IPrincess
{
    private readonly IFriend _friend;
    private readonly IHall _hall;
    private readonly StringBuilder _cameChallengersStringBuilder;

    public PrincessImpl(IFriend friend, IHall hall)
    {
        _friend = friend;
        _hall = hall;
        _cameChallengersStringBuilder = new StringBuilder();
    }

    public void FriendRefresh()
    {
        _friend.Refresh();
    }

    public void UpdateHall(List<HusbandChallenger> challengers)
    {
        _hall.SetChallengerList(challengers);
    }

    public string TellWhoIsHusband()
    {
        var husbandChallenger = Choose();
        var result = TellWhoWasChosen(husbandChallenger);
        _cameChallengersStringBuilder.Append(result);
        return _cameChallengersStringBuilder.ToString();
    }
    
    public HusbandChallenger? Choose()
    {
        var challengersAmount = _hall.GetChallengerAmount();
        if (challengersAmount == 0)
        {
            throw new CustomException(ErrorType.HallIsEmpty());
        }
        var passChallengersAmount = GetPassChallengersAmount(challengersAmount);
        var currentChallengerNumber = 1;
        while (currentChallengerNumber <= challengersAmount)
        {
            var nextChallenger = _hall.GetNextChallenger();
            TellWhoComeIn(currentChallengerNumber, nextChallenger);
            nextChallenger.MetWithPrincess = true;
            if (currentChallengerNumber <= passChallengersAmount)
            {
                _friend.AddNewChallenger(nextChallenger);
                currentChallengerNumber++;
                continue;
            }
            if (_friend.IsBetter(nextChallenger))
            {
                return nextChallenger;
            }
            _friend.AddNewChallenger(nextChallenger);
            currentChallengerNumber++;
        }

        return null;
    }

    public int GetPassChallengersAmount(int challengerAmount)
    {
        return Convert.ToInt32(Math.Round(challengerAmount/Math.E));
    }

    private void TellWhoComeIn(int iteration, HusbandChallenger challenger)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(iteration)
            .Append(") ")
            .Append(challenger.Name);
        _cameChallengersStringBuilder
            .Append(stringBuilder)
            .Append('\n');
    }

    private static string TellWhoWasChosen(HusbandChallenger? challenger)
    {
        if (challenger == null)
        {
            return "No one";
        }

        var stringBuilder = new StringBuilder();
        stringBuilder.Append(Constants.Delimiter)
            .Append('\n')
            .Append("Chosen: ")
            .Append(challenger.Name)
            .Append(" - ")
            .Append(challenger.Rating);
        return stringBuilder.ToString();
    }
}