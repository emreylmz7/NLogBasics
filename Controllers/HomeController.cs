using Microsoft.AspNetCore.Mvc;

namespace NLogBasics.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HomeController : ControllerBase
{
    private readonly ILogger<HomeController> _logger;
    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _logger.LogDebug(1, "NLog Enjected into HomeController");
    }

    [HttpGet]
    public IActionResult Get()
    {
        _logger.LogInformation("Hello This is the Get Api Log");
        return NoContent();
    }
}
