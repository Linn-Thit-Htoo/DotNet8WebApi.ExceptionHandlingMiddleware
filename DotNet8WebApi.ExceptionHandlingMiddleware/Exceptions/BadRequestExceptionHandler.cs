using DotNet8WebApi.ExceptionHandlingMiddleware.Models;
using Microsoft.AspNetCore.Diagnostics;

namespace DotNet8WebApi.ExceptionHandlingMiddleware.Exceptions;

public class BadRequestExceptionHandler : IExceptionHandler
{
    private readonly ILogger<BadRequestExceptionHandler> _logger;

    public BadRequestExceptionHandler(ILogger<BadRequestExceptionHandler> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(
        HttpContext httpContext,
        Exception exception,
        CancellationToken cancellationToken
    )
    {
        if (exception is not BadHttpRequestException)
        {
            return false;
        }

        _logger.LogError(exception.ToString());
        var result = Result<string>.Fail(exception);

        httpContext.Response.StatusCode = Convert.ToInt32(result.StatusCode);
        await httpContext.Response.WriteAsJsonAsync(result, cancellationToken: cancellationToken);

        return true;
    }
}
