namespace iToiletOnDapr.Rating.Ratings;

public interface IRatingRepository
{
    Task Add(Rating rating);
    Task<Rating> Get(Guid id);
    Task<IEnumerable<Rating>> GetAll();
}