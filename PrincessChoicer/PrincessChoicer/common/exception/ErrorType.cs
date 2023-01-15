namespace PrincessChoicer.common.exception;

public class ErrorType
{
    private ErrorCode _errorCode;
    private string _errorMessage;

    private ErrorType(ErrorCode errorCode, string errorMessage)
    {
        _errorCode = errorCode;
        _errorMessage = errorMessage;
    }

    public static ErrorType HallIsEmpty()
    {
        return new ErrorType(ErrorCode.HallIsEmpty,
            "No more challengers in the hall");
    }

    public static ErrorType UnfamiliarChallenger()
    {
        return new ErrorType(ErrorCode.NotFamiliarChallenger,
            "Not familiar with princess");
    }

    public static ErrorType RandomFullNameNetError()
    {
        return new ErrorType(ErrorCode.RandomFullNamesNetError,
            "There are problems with getting random fullNames from Net");
    }

    public string GetErrorMessage()
    {
        return $"{_errorCode}: {_errorMessage}";
    }
}