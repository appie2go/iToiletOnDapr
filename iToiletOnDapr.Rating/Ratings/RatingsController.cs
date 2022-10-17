using Microsoft.AspNetCore.Mvc;

namespace iToiletOnDapr.Rating.Ratings;

[ApiController]
[Route("[controller]")]
public class RatingsController : ControllerBase
{
    private readonly ILogger<RatingsController> _logger;
    private readonly IRatingRepository _ratingRepository;

    public RatingsController(ILogger<RatingsController> logger, IRatingRepository ratingRepository)
    {
        _logger = logger;
        _ratingRepository = ratingRepository;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var ratings = await _ratingRepository.GetAll();
        return new OkObjectResult(ratings);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var rating = await _ratingRepository.Get(id);
            return new OkObjectResult(rating);
        }
        catch (NotFoundException)
        {
            return new NotFoundResult();
        }
    }
    
    [HttpPost]
    public async Task<IActionResult> Post(Rating newRating)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }

        await _ratingRepository.Add(newRating);

        return Ok();
    }
}