namespace iToiletOnDapr.Location.Toilets;

public class Toilet
{
    public Guid Id { get; set; }

    public string? Address { get; set; }

    public int Floor { get; set; }

    public string? Description { get; set; }
}