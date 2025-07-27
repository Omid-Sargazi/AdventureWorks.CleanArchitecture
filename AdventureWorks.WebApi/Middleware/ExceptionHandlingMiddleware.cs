using System.Net;
using System.Text.Json;
using AdventureWorks.Application.Exceptions;

namespace AdventureWorks.WebApi.Middleware
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionHandlingMiddleware> _logger;
        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _logger = logger;
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {

                _logger.LogError(ex, "An unhandled exception occurred while processing the request");

                var resposne = context.Response; 
                resposne.ContentType = ("application/json");

                var statusCode = (int)HttpStatusCode.InternalServerError;
                string message = "Internal Server Error";

                if (ex is AppException appEx)
                {
                    statusCode = appEx.StatusCode;
                    message = appEx.Message;
                }

                resposne.StatusCode = statusCode;

                var errorResponse = new
                {
                    statusCode,
                    message,
                    detail = ex is AppException ? null : ex.Message
                };

                await context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
            }
        }
    }
}