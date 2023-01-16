using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrincessChoicer.common.exception;
using PrincessChoicer.common.model;
using PrincessChoicer.common.model.impl;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace PrincessChoicerTest.lab3;

[TestClass]
public class HallTest
{
    private readonly IHall _hall;

    public HallTest()
    {
        _hall = new HallImpl();
    }
    
    [TestMethod]
    public void NextChallengerOk()
    {
        const int rating = 30;
        const string name = "name 0";
        var expectedChallenger = new HusbandChallenger(name, rating);
        
        var challengerList = TestUtils.CreateChallengerList(new List<int>() {rating});
        _hall.SetChallengerList(challengerList);

        var actualChallenger = _hall.GetNextChallenger();
        Assert.IsTrue(TestUtils.AreEqualChallengers(actualChallenger, expectedChallenger));
    }

    [TestMethod]
    public void EmptyHallException()
    {
        var challengerList = TestUtils.CreateChallengerList(new List<int>() {30, 60});
        _hall.SetChallengerList(challengerList);
        _hall.GetChallengerAmount();
        for (int i = 0; i < _hall.GetChallengerAmount(); i++)
        {
            _hall.GetNextChallenger();
        }
        
        var providedException = Assert.ThrowsException<CustomException>(() => _hall.GetNextChallenger());
        Assert.AreEqual(providedException.Message, 
            ErrorType.HallIsEmpty().GetErrorMessage());
    }
}