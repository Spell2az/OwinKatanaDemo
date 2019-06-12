using Microsoft.AspNetCore.Builder;

namespace OwinKatanaDemo.Middleware
{
    public static class DebugMiddlewareExtensions
    {
        public static IApplicationBuilder UseDebugMiddleware(this IApplicationBuilder builder, DebugMiddlewareOptions options)
        {
            return builder.UseMiddleware<DebugMiddleware>(options);
        }
    }
}