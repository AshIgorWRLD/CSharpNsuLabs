namespace PrincessChoicer.common.exception;

public class CustomException : Exception
{
    public CustomException(ErrorType errorType) :
        base(errorType.GetErrorMessage())
    {
    }
    
}