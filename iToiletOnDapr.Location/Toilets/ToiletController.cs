using Microsoft.AspNetCore.Mvc;

namespace iToiletOnDapr.Location.Toilets;

[ApiController]
[Route("[controller]")]
public class ToiletController : ControllerBase
{
    private readonly ILogger<ToiletController> _logger;
    private readonly IToiletRepository _repository;

    public ToiletController(ILogger<ToiletController> logger, IToiletRepository repository)
    {
        _logger = logger;
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult> Get()
    {
        var items = await _repository.GetAll();
        return new OkObjectResult(items);
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetById([FromRoute] Guid id)
    {
        try
        {
            var item = await _repository.Get(id);
            return new OkObjectResult(item);
        }
        catch (NotFoundException)
        {
            return new NotFoundResult();
        }
    }
    
    [HttpPost]
    public async Task<ActionResult> Post([FromBody] Toilet payload)
    {
        try
        {
            await _repository.Add(payload);
            return new OkResult();
        }
        catch (KeyTakenException)
        {
            return new ConflictObjectResult(new Error($"An item with id ${payload.Id} already exists."));
        }
    }
    
    [HttpPut]
    public async Task<ActionResult> Put([FromBody] Toilet payload)
    {
        try
        {
            await _repository.Update(payload);
            return new OkResult();
        }
        catch (NotFoundException)
        {
            return new NotFoundResult();
        }
    }
        
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete([FromRoute] Guid id)
    {
        try
        {
            await _repository.Delete(id);
            return new OkResult();
        }
        catch (NotFoundException)
        {
            return new NotFoundResult();
        }
    }
}