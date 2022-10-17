namespace iToiletOnDapr.Rating;

public class KeyTakenException : Exception
{
    public KeyTakenException()
    {
        
    }

    public KeyTakenException(string exceptionMessage) : base(exceptionMessage)
    {

    }

    public KeyTakenException(string exceptionMessage, Exception exception) : base(exceptionMessage, exception)
    {
        
    }
}