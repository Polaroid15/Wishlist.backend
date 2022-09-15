using Wishlist.Core;
using Wishlist.Core.Exceptions;
using Wishlist.Core.Interfaces;

namespace Wishlist.API.Middleware; 

public class ExceptionMiddleware {
    private readonly RequestDelegate _next;
    private readonly IAppLogger<ExceptionMiddleware> _logger;

    public ExceptionMiddleware(RequestDelegate next, IAppLogger<ExceptionMiddleware> logger) {
        _next = next;
        _logger = logger;
    }
    
    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(httpContext, ex);        
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        _logger.LogCritical(exception.Message);
        context.Response.ContentType = "application/json";

        context.Response.StatusCode = exception switch {
            NotFoundException => StatusCodes.Status404NotFound,
            _ => StatusCodes.Status500InternalServerError
        };
        await context.Response.WriteAsync(new ErrorDetails()
        {
            StatusCode = context.Response.StatusCode,
            Message = exception.Message
        }.ToString());
    }
}