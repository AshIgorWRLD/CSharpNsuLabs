using PrincessChoicer.model;

namespace PrincessChoicer.utils;

public static class Shuffler
{
    private static Random random = new Random();
    
    public static void shuffle<T>(ref List<T> list)
    {
        int listLength = list.Count;
        for (int i = listLength - 1; i > 0; i--)
        {
            int j = random.Next(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}