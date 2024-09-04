using DotNet8WebApi.ExceptionHandlingMiddleware.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace DotNet8WebApi.ExceptionHandlingMiddleware.Exceptions;

public class GlobalExceptionHandler : IExceptionHandler
{
    private readonly ILogger<GlobalExceptionHandler> _logger;

    public GlobalExceptionHandler(ILogger<GlobalExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception.ToString());
        var result = Result<string>.Fail(exception.ToString());

        httpContext.Response.StatusCode = Convert.ToInt32(result.StatusCode);
        await httpContext.Response
            .WriteAsJsonAsync(result, cancellationToken);

        return true;
    }
}
