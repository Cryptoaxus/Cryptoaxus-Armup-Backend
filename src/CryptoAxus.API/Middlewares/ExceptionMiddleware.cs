namespace CryptoAxus.API.Middlewares;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            await _next(httpContext);
        }
        catch (Exception exception)
        {
            await HandleExceptionAsync(httpContext, exception);
        }
    }

    private async Task<Task> HandleExceptionAsync(HttpContext httpContext, Exception exception)
    {
        httpContext.Response.ContentType = "application/json";

        httpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

        var response = new BaseResponse<object>(HttpStatusCode.InternalServerError, "InternalServerError", null)
        {
            ApiException = new ApiException(null, "Internal Server Error Occurred", exception.Message,
                                            exception.InnerException?.Message!, exception.HelpLink)
        };

        return httpContext.Response.WriteAsync(JsonConvert.SerializeObject(response));
    }
}