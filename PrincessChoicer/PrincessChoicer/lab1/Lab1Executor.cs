using PrincessChoicer.common.model.impl;
using PrincessChoicer.common.utils;

namespace PrincessChoicer.lab1;

public static class Lab1Executor
{
    // public static void Main(string[] args)
    // {
    //     HelpPrincess();
    // }

    public static void HelpPrincess()
    {
        var contentGenerator = new ContentGeneratorImpl();
        var challengerList = contentGenerator.GenerateChallengerList();
        var hall = new HallImpl();
        hall.SetChallengerList(challengerList);
        var friend = new FriendImpl();
        Console.WriteLine(Constants.Delimiter);
        var princess = new PrincessImpl(friend, hall);
        var result = princess.TellWhoIsHusband();
        Printer.PrintResultToConsole(result);
    }
}