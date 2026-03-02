using Microsoft.AspNetCore.Mvc;

namespace DelegatingHandler.Server.Controllers;

[ApiController]
[Route("api/ping")]
public class PingController : ControllerBase
{
    // GET
    [HttpGet]
    public IActionResult Get()
    {
        Console.WriteLine("[Server Controller] /api/ping hit");
        return Ok(new { message = "pong", at = DateTimeOffset.Now });
    }
}