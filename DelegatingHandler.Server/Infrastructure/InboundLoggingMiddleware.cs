namespace DelegatingHandler.Server.Infrastructure;

public class InboundLoggingMiddleware(RequestDelegate next)
{
    public async Task InvokeAsync(HttpContext context)
    {
        Console.WriteLine($"[Server Middleware] INBOUND: {context.Request.Method} {context.Request.Path}");
        await next(context);
        Console.WriteLine($"[Server Middleware] OUTBOUND: {context.Response.StatusCode}");
    }
}