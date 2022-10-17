namespace iToiletOnDapr.Location;

public class NotFoundException : Exception
{
    public NotFoundException()
    {
        
    }

    public NotFoundException(string exceptionMessage) : base(exceptionMessage)
    {

    }

    public NotFoundException(string exceptionMessage, Exception exception) : base(exceptionMessage, exception)
    {
        
    }
}