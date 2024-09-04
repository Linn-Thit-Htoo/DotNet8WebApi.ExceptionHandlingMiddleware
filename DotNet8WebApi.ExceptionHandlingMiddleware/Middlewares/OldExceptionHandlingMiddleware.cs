namespace DotNet8WebApi.ExceptionHandlingMiddleware.Middlewares;

public class OldExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<OldExceptionHandlingMiddleware> _logger;

    public OldExceptionHandlingMiddleware(
        RequestDelegate next,
        ILogger<OldExceptionHandlingMiddleware> logger
    )
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        Result<string> result;
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.ToString());
            result = Result<string>.Fail(ex);

            context.Response.StatusCode = Convert.ToInt32(result.StatusCode);
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}
