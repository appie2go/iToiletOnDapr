namespace iToiletOnDapr.Rating.Location;

public interface ILocationService
{
    Task<bool> Exists(Guid locationId);
}