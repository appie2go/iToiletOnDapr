using System.ComponentModel.DataAnnotations;

namespace iToiletOnDapr.Rating.Ratings;

public class Rating
{
    public Guid Id { get; set; }
    public Guid ToiletId { get; set; }
    
    [Range(1, 5)]
    public int Stars { get; set; }
}