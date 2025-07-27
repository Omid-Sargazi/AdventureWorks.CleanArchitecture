namespace AdventureWorks.Application.Exceptions
{
    public class AppException : Exception
    {
        public int StatusCode { get; set; }

        public AppException(string message, int statusCode = 400) : base(message)
        {
            StatusCode = statusCode;
        }
    }

    public class NotFoundException : AppException
    {
        public NotFoundException(string entity, object key) : base($"{entity} with key {key} was not found.", 404)
        {
        }
    }

    public class ValidationException : AppException
    {
        public ValidationException(string message) : base(message, 400)
        {
        }
    }

    public class UnauthorizedException : AppException
    {
        public UnauthorizedException(string message = "Unauthorized") : base(message, 401)
        {
        }
    }
}