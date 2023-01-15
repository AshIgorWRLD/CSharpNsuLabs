using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrincessChoicer.common.model;
using PrincessChoicer.common.model.impl;

namespace PrincessChoicerTest.lab3;

[TestClass]
public class ContentGeneratorTest
{
    private readonly IContentGenerator _contentGenerator;

    public ContentGeneratorTest()
    {
        _contentGenerator = new ContentGeneratorImpl();
    }
    
    [TestMethod]
    public void RandomGenerationOk()
    {
        var challengerList = _contentGenerator.GenerateChallengerList();
        var challengerSet = challengerList.Select(challenger => (challenger.Name, challenger.Rating));

        Assert.AreEqual(100, challengerSet.Count());
    }
}