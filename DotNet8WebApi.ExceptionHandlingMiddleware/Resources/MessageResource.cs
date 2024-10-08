﻿namespace DotNet8WebApi.ExceptionHandlingMiddleware.Resources;

public class MessageResource
{
    public static string Success { get; } = "Success.";
    public static string SaveSuccess { get; } = "Saving Successful.";
    public static string SaveFail { get; } = "Saving Fail.";
    public static string UpdateSuccess { get; } = "Updating Successful.";
    public static string UpdateFail { get; } = "Updating Fail.";
    public static string DeleteSuccess { get; } = "Deleting Successful.";
    public static string DeleteFail { get; } = "Deleting Fail.";
    public static string NotFound { get; } = "No Data Found.";
}
