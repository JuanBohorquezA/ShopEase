using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Http;
using ShopEase.Domain.Exceptions;
using ShopEase.Presentation.Responses;
using System.Net;
using System.Text.Json;

namespace ShopEase.Presentation.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    #region private methods
    private static Task HandleExceptionAsync(HttpContext context, Exception exception)
    {

        var httpResponse = new HttpErrorResponse { statusCode = 500, description = HttpStatusDescriptions.status500, message =  new List<string> { exception.Message}};

        if (exception is ForbiddenException)
        {
            httpResponse.statusCode = (int)HttpStatusCode.Forbidden;
            httpResponse.description = HttpStatusDescriptions.status403;
            httpResponse.message = new List<string> { exception.Message };
        }
        else if (exception is UnauthorizedException)
        {
            httpResponse.statusCode = (int)HttpStatusCode.Unauthorized;
            httpResponse.description = HttpStatusDescriptions.status401;
            httpResponse.message = new List<string> { exception.Message};
        }
        else if (exception is ValidationException validationException)
        {
            httpResponse.statusCode = (int)HttpStatusCode.BadRequest;
            httpResponse.description = HttpStatusDescriptions.status400;
            httpResponse.message = ConvertValidationFailures(validationException.Errors);
        }
         

        var result = JsonSerializer.Serialize(httpResponse);
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = httpResponse.statusCode;
        return context.Response.WriteAsync(result);
    }

    private static IEnumerable<string> ConvertValidationFailures(IEnumerable<ValidationFailure> failures)
    {
        var errors = new List<string>();
        foreach (var failure in failures)
        {
            errors.Add(failure.ErrorMessage);
        }
        return errors;
    }
    #endregion
}
