using NuGet.Common;
using System.Diagnostics;

namespace Test.MiddleWares
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;

        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }
        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();
            await _next(context);
            stopwatch.Stop();

            if (stopwatch.ElapsedMilliseconds > 500)
            {
                _logger.LogWarning($"Request took {stopwatch.ElapsedMilliseconds} ms: {context.Request.Path}");
            }
        }
    }
}
