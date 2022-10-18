using Microsoft.AspNetCore.Mvc;

namespace iToiletOnDapr.Rating.Echo;

[ApiController]
[Route("ratings/echo")]
public class EchoController : ControllerBase
{
    public EchoController()
    {
        
    }

    [HttpGet]
    public ActionResult Get()
    {
        var hugghhh = Request.Headers.Select(x => $"Key: {x.Key} + Value: {x.Value}");

        return new OkObjectResult(hugghhh);
    }
}