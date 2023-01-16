using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrincessChoicer.common.exception;
using PrincessChoicer.common.model;
using PrincessChoicer.common.model.impl;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrincessChoicerTest.lab3;

[TestClass]
public class PrincessTest
{
    private readonly IFriend _friend;
    private readonly IHall _hall;
    private readonly IPrincess _princess;

    public PrincessTest()
    {
        _friend = new FriendImpl();
        _hall = new HallImpl();
        _princess = new PrincessImpl(_friend, _hall);
    }
    
    [TestMethod]
    public void PrincessStrategyOk()
    {
        const int rating = 40;
        const string name = "name 3";
        var expectedChosenChallenger = new HusbandChallenger(name, rating);

        const int expectedPassAmount = 3;
        
        var challengerList = TestUtils.CreateChallengerList(new List<int>() {10, 20, 30, 40, 50, 60, 70, 80, 90});
        _princess.UpdateHall(challengerList);
        var actualPassAmount = _princess.GetPassChallengersAmount(challengerList.Count);

        Assert.AreEqual(actualPassAmount, expectedPassAmount);
        
        var actualChosenChallenger = _princess.Choose();
        
        Assert.IsTrue(TestUtils.AreEqualChallengers(actualChosenChallenger, expectedChosenChallenger));
    }

    [TestMethod]
    public void EmptyHallExceptionInPrincess()
    {
        var emptyList = new List<HusbandChallenger>();
        _princess.UpdateHall(emptyList);
        var providedException = Assert.ThrowsException<CustomException>(() => _princess.Choose());
        Assert.AreEqual(providedException.Message, 
            ErrorType.HallIsEmpty().GetErrorMessage());
    }
}