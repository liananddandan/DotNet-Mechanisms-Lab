namespace DelegatingHandler.Client.Infrastructure;

public class OutboundLoggingHandler() : System.Net.Http.DelegatingHandler
{
    protected override async  Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, 
        CancellationToken cancellationToken)
    {
        Console.WriteLine($"[Client DelegatingHandler] OUTBOUND request: {request.Method} {request.RequestUri}");
        var response = await base.SendAsync(request, cancellationToken);
        Console.WriteLine($"[Client DelegatingHandler] OUTBOUND response: {(int)response.StatusCode} {response.StatusCode}");
        return response;
    }
}