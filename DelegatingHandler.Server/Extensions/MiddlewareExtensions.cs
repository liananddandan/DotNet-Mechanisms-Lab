using DelegatingHandler.Server.Infrastructure;

namespace DelegatingHandler.Server.Extensions;

public static class MiddlewareExtensions
{
    public static IApplicationBuilder UseInboundLogging(this IApplicationBuilder app)
    {
        return app.UseMiddleware<InboundLoggingMiddleware>();
    }
}