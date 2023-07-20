namespace CryptoAxus.API.Extensions;

public static class ExceptionMiddlewareExtensions
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                context.Response.ContentType = Constants.ContentTypeJson;

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature is not null)
                {
                    await context.Response.WriteAsync(new ApiException(null,
                                                                       "Internal Server Error from the custom middleware.",
                                                                       string.Empty,
                                                                       string.Empty,
                                                                       null).ToString() ?? string.Empty);
                }
            });
        });
    }

    public static void ConfigureCustomMiddleware(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionMiddleware>();
    }
}