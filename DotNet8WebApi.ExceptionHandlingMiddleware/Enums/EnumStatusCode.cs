namespace DotNet8WebApi.ExceptionHandlingMiddleware.Enums
{
    public enum EnumStatusCode
    {
        None,
        OK = 200,
        Created = 201,
        Accepted = 202,
        BadRequest = 400,
        NotFound = 404,
        Conflict = 409,
        Locked = 423,
        InternalServerError = 500
    }
}
