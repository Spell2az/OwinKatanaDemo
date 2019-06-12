using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace OwinKatanaDemo.Middleware
{
    public class DebugMiddleware
    {
        private readonly RequestDelegate next;
        private readonly DebugMiddlewareOptions options;

        public DebugMiddleware(RequestDelegate next, DebugMiddlewareOptions options)
        {
            this.next = next;
            this.options = options;

            if (options.OnIncomingRequest == null)
            {
                options.OnIncomingRequest = ctx => Debug.WriteLine("Incoming request " + ctx.Request.Path);
            }
            
            if (options.OnOutgoingRequest == null)
            {
                options.OnOutgoingRequest = ctx => Debug.WriteLine("Outgoint request " + ctx.Request.Path);
            }
        }

        public async Task Invoke(HttpContext ctx)
        {
            options.OnIncomingRequest(ctx);
            await next(ctx);
            options.OnOutgoingRequest(ctx);
        }
    }
}