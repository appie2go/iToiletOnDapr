namespace iToiletOnDapr.Location.Toilets;

public interface IToiletRepository
{
    Task Add(Toilet toilet);
    Task Update(Toilet toilet);
    Task Delete(Guid toiletId);
    Task<Toilet> Get(Guid id);
    Task<IEnumerable<Toilet>> GetAll();
}