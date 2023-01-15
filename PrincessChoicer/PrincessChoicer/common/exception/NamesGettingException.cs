namespace PrincessChoicer.common.exception;

public class NamesGettingException : Exception
{
    public NamesGettingException(ErrorType errorType) :
        base($"{errorType.ErrorCode}: {errorType.Message}")
    {
    }
    
}