using DotNet8WebApi.ExceptionHandlingMiddleware.Enums;
using DotNet8WebApi.ExceptionHandlingMiddleware.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace DotNet8WebApi.ExceptionHandlingMiddleware.Exceptions
{
    public class GlobalExceptionHandler : IExceptionHandler
    {
        private readonly ILogger<GlobalExceptionHandler> _logger;
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            Result<string> result;

            _logger.LogError(exception.ToString());
            result = Result<string>.Fail(exception.ToString());

            httpContext.Response.StatusCode = Convert.ToInt32(EnumStatusCode.InternalServerError);
            await httpContext.Response
            .WriteAsJsonAsync(result, cancellationToken);

            return true;
        }
    }
}
