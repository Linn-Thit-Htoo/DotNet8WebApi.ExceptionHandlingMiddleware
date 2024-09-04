namespace DotNet8WebApi.ExceptionHandlingMiddleware.Middlewares
{
    public class OldExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<OldExceptionHandlingMiddleware> _logger;

        public OldExceptionHandlingMiddleware(RequestDelegate next, ILogger<OldExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                var problemDetails = new
                {
                    Status = 500,
                    Title = "Internal Server Error"
                };

                context.Response.StatusCode = problemDetails.Status;
                await context.Response.WriteAsJsonAsync(problemDetails);
            }
        }
    }
}
