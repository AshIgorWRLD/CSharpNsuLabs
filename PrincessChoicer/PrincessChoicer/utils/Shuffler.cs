namespace PrincessChoicer.utils;

public static class Shuffler
{
    private static readonly Random Random = new Random();
    
    public static void Shuffle<T>(ref List<T> list)
    {
        var listLength = list.Count;
        for (var i = listLength - 1; i > 0; i--)
        {
            var j = Random.Next(0, i + 1);
            (list[i], list[j]) = (list[j], list[i]);
        }
    }
}