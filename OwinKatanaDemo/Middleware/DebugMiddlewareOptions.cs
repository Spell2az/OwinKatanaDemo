using System;
using Microsoft.AspNetCore.Http;

namespace OwinKatanaDemo.Middleware
{
    public class DebugMiddlewareOptions
    {
        public Action<HttpContext> OnIncomingRequest { get; set; }
        public Action<HttpContext> OnOutgoingRequest { get; set; }
    }
}