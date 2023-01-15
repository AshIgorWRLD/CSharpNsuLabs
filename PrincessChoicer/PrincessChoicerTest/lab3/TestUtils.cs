using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualBasic.CompilerServices;
using PrincessChoicer.common.model;
using PrincessChoicer.common.utils;

namespace PrincessChoicerTest.lab3;


public class TestUtils
{
    public static List<HusbandChallenger> CreateChallengerList(List<int> ratingList)
    {
        var list = new List<HusbandChallenger>();
        for (int i = 0; i < ratingList.Count; i++)
        {
            list.Add(new HusbandChallenger("name " + i, ratingList[i]));
        }

        return list;
    }

    public static bool AreEqualChallengers(HusbandChallenger actual, HusbandChallenger expected)
    {
        return actual.Name.Equals(expected.Name) && actual.Rating.Equals(expected.Rating);
    }
}