namespace iToiletOnDapr.Location.Toilets;

public class ToiletRepository : IToiletRepository
{
    private static List<Toilet> Toilets { get; } = new ();

    public Task Add(Toilet toilet)
    {
        if (Toilets.Any(x => x.Id == toilet.Id))
        {
            throw new KeyTakenException($"Unable to comply. An item with Id ${toilet.Id} already exists.");
        }

        Toilets.Add(toilet);
        return Task.CompletedTask;
    }

    public async Task Update(Toilet toilet)
    {
        await Delete(toilet.Id);
        Toilets.Add(toilet);
    }

    public Task Delete(Guid toiletId)
    {
        Toilet itemInCollection;
        try
        {
            itemInCollection = Toilets.Single(x => x.Id == toiletId);
        }
        catch (Exception e)
        {
            throw new NotFoundException($"Unable to comply. Unable to retrieve item with Id ${toiletId}.", e);
        }

        Toilets.Remove(itemInCollection);
        return Task.CompletedTask;
    }

    public Task<Toilet> Get(Guid id)
    {
        try
        {
            var result = Toilets.Single(x => x.Id == id);
            return Task.FromResult(result);
        }
        catch (Exception e)
        {
            throw new NotFoundException($"Unable to comply. Unable to retrieve item with Id ${id}.", e);
        }
    }
    
    public Task<IEnumerable<Toilet>> GetAll()
    {
        var result = (IEnumerable<Toilet>)Toilets;
        return Task.FromResult(result);
    }
}