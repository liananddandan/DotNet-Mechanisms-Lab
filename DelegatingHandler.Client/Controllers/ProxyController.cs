using Microsoft.AspNetCore.Mvc;

namespace DelegatingHandler.Client.Controllers;

[ApiController]
[Route("api/proxy")]
public class ProxyController : ControllerBase
{
    private readonly HttpClient _serverClient;
    
    public ProxyController(IHttpClientFactory factory)
    {
        _serverClient = factory.CreateClient("DelegatingHandlerServer");
    }
    
    [HttpGet("ping")]
    public async Task<IActionResult> Ping(CancellationToken ct)
    {
        Console.WriteLine("[Client Controller] /api/proxy/ping hit -> calling Server /api/ping");

        var json = await _serverClient.GetStringAsync("api/ping", ct);

        return Ok(new
        {
            message = "client-proxy-ok",
            serverResponse = json
        });
    }
    
    [HttpGet("local-only")]
    public IActionResult LocalOnly()
    {
        Console.WriteLine("[Server Controller] local-only endpoint hit");
        return Ok("no outbound call");
    }
}