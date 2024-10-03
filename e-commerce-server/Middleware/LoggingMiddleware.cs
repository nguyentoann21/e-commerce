namespace e_commerce_server.Middleware
{
    public class LoggingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<LoggingMiddleware> _logger;

        public LoggingMiddleware(RequestDelegate next, ILogger<LoggingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                // Log the incoming request
                _logger.LogInformation("Handling request: {Method} {Path}", context.Request.Method, context.Request.Path);

                // Call the next middleware in the pipeline
                await _next(context);

                // Log the response status code after the next middleware completes
                LogStatusCode(context);
            }
            catch (Exception ex)
            {
                // Log any unhandled exceptions
                _logger.LogError(ex, "An error occurred while processing the request");
                throw;
            }
        }

        private void LogStatusCode(HttpContext context)
        {
            var statusCode = context.Response.StatusCode;

            if (statusCode >= 200 && statusCode < 300)
            {
                _logger.LogInformation("Request succeeded with status code: {StatusCode}", statusCode);
            }
            else if (statusCode >= 300 && statusCode < 400)
            {
                _logger.LogInformation("Request resulted in a redirection with status code: {StatusCode}", statusCode);
            }
            else if (statusCode >= 400 && statusCode < 500)
            {
                _logger.LogWarning("Client error with status code: {StatusCode}", statusCode);
            }
            else if (statusCode >= 500)
            {
                _logger.LogError("Server error with status code: {StatusCode}", statusCode);
            }
            else
            {
                _logger.LogInformation("Unhandled status code: {StatusCode}", statusCode);
            }
        }
    }
}
