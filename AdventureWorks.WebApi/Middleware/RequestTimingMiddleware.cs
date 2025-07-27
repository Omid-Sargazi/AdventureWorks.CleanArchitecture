using System.Diagnostics;

namespace AdventureWorks.WebApi.Middleware
{
    public class RequestTimingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<RequestTimingMiddleware> _logger;
        public RequestTimingMiddleware(RequestDelegate next, ILogger<RequestTimingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var stopwatch = Stopwatch.StartNew();

            await _next(context);

            stopwatch.Stop();
            var elapsed = stopwatch.ElapsedMilliseconds;

            _logger.LogInformation("Request [{method}] {url} took {time}ms",
            context.Request.Method,
            context.Request.Path, elapsed);
        }
    }
}