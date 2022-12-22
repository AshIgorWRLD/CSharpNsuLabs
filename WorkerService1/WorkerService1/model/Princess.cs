using WorkerService1.utils;

namespace WorkerService1.model;

using System.Text;

public class Princess : BackgroundService
{
    private readonly Friend _friend;
    private readonly Hall _hall;

    public Princess(Friend friend, Hall hall)
    {
        _friend = friend;
        _hall = hall;
    }

    public void TellWhoIsHusband()
    {
        var husbandChallenger = Choose();
        TellWhoWasChosen(husbandChallenger);
    }
    
    private HusbandChallenger? Choose()
    {
        var challengersAmount = _hall.GetChallengerAmount();
        var passChallengersAmount = GetPassChallengersAmount(challengersAmount);
        var currentChallengerNumber = 1;
        while (currentChallengerNumber <= challengersAmount)
        {
            var nextChallenger = _hall.GetNextChallenger();
            TellWhoComeIn(currentChallengerNumber, nextChallenger);
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

    private static int GetPassChallengersAmount(int challengerAmount)
    {
        return Convert.ToInt32(Math.Round(challengerAmount/Math.E));
    }

    private static void TellWhoComeIn(int iteration, HusbandChallenger challenger)
    {
        var stringBuilder = new StringBuilder();
        stringBuilder.Append(iteration)
            .Append(") ")
            .Append(challenger.Name);
        Console.WriteLine(stringBuilder);
    }

    private static void TellWhoWasChosen(HusbandChallenger? challenger)
    {
        Console.WriteLine(Constants.Delimiter);
        if (challenger == null)
        {
            Console.WriteLine("No one");
            return;
        }

        var stringBuilder = new StringBuilder();
        stringBuilder.Append(challenger.Name)
            .Append(": ")
            .Append(challenger.Rating);
        
        Console.WriteLine(stringBuilder);
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            TellWhoIsHusband();
            await Task.Delay(1000, stoppingToken);
        }
    }
}