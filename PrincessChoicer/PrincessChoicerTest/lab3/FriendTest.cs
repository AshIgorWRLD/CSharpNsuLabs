using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrincessChoicer.common.exception;
using PrincessChoicer.common.model;
using PrincessChoicer.common.model.impl;

namespace PrincessChoicerTest.lab3;

[TestClass]
public class FriendTest
{
    private readonly IFriend _friend;
    
    public FriendTest()
    {
        _friend = new FriendImpl();
    }
    
    [TestMethod]
    public void RightComparisonOk()
    {
        const int ratingA = 30;
        const string nameA = "name 0";
        var challengerA = new HusbandChallenger(nameA, ratingA);
        challengerA.MetWithPrincess = true;
        
        const int ratingB = 60;
        const string nameB = "name 1";
        var challengerB = new HusbandChallenger(nameB, ratingB);
        challengerB.MetWithPrincess = true;

        var isBBetter = _friend.IsBetter(challengerB);
        Assert.IsTrue(isBBetter);
        
        _friend.AddNewChallenger(challengerB);

        var isABetter = _friend.IsBetter(challengerA);
        Assert.IsFalse(isABetter);
    }

    [TestMethod]
    public void UnfamiliarChallengerException()
    {
        const int rating = 30;
        const string name = "name 0";
        var challenger = new HusbandChallenger(name, rating);
        
        var providedException = Assert.ThrowsException<CustomException>(() => _friend.IsBetter(challenger));
        Assert.AreEqual(providedException.Message,
            ErrorType.UnfamiliarChallenger().GetErrorMessage());
    }
    
}