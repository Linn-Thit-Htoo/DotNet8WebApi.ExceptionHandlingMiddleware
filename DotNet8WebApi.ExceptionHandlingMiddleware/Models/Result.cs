using DotNet8WebApi.ExceptionHandlingMiddleware.Enums;

namespace DotNet8WebApi.ExceptionHandlingMiddleware.Models;

public class Result<T>
{
    public string Message { get; set; }
    public T Data { get; set; }
    public bool IsSuccess { get; set; }
    public EnumStatusCode StatusCode { get; set; }

    public static Result<T> Success(string message = "Success.")
    {
        return new Result<T>
        {
            Message = message,
            StatusCode = EnumStatusCode.OK,
            IsSuccess = true
        };
    }

    public static Result<T> Success(T data, string message = "Success.")
    {
        return new Result<T>
        {
            Message = message,
            Data = data,
            StatusCode = EnumStatusCode.OK,
            IsSuccess = true
        };
    }

    public static Result<T> Fail(string message = "Fail.")
    {
        return new Result<T>
        {
            Message = message,
            StatusCode = EnumStatusCode.BadRequest,
            IsSuccess = false
        };
    }

    public static Result<T> Fail(Exception ex)
    {
        return new Result<T>
        {
            Message = ex.ToString(),
            StatusCode = EnumStatusCode.InternalServerError,
            IsSuccess = false
        };
    }
}
