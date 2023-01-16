namespace PrincessChoicer.common.model;

public class StrategyResponse
{
    public string Message { get; }
    public HusbandChallenger? Challenger { get; }

    private StrategyResponse(string message, HusbandChallenger? challenger)
    {
        Message = message;
        Challenger = challenger;
    }

    public static StrategyResponse InvalidContender()
    {
        return new StrategyResponse("Invalid contender", null);
    }

    public static StrategyResponse NotEnoughInfo()
    {
        return new StrategyResponse("Not enough info to decide who is better...", null);
    }

    public static StrategyResponse ItCanBeBetter()
    {
        return new StrategyResponse("There is information that this one isn't best...", null);
    }

    public static StrategyResponse ThatIsBestChoice(HusbandChallenger contender)
    {
        return new StrategyResponse("This maaan is good choice", contender);
    }

    public static StrategyResponse NoVariantsSuitable()
    {
        return new StrategyResponse("It can be better to stay old maid", null);
    }
}