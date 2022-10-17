namespace iToiletOnDapr.Rating.Ratings;

public class RatingRepository : IRatingRepository
{
    private static List<Rating> Ratings { get; } = new ();

    public Task Add(Rating rating)
    {
        if (Ratings.Any(x => x.Id == rating.Id))
        {
            throw new KeyTakenException($"Unable to comply. An item with Id ${rating.Id} already exists.");
        }

        Ratings.Add(rating);
        return Task.CompletedTask;
    }

    public Task<Rating> Get(Guid id)
    {
        try
        {
            var result = Ratings.Single(x => x.Id == id);
            return Task.FromResult(result);
        }
        catch (Exception e)
        {
            throw new NotFoundException($"Unable to comply. Unable to retrieve item with Id ${id}.", e);
        }
    }
    
    public Task<IEnumerable<Rating>> GetAll()
    {
        var result = (IEnumerable<Rating>)Ratings;
        return Task.FromResult(result);
    }
}