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
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    await context.Response.WriteAsync(new ApiException(null,
                                                                       "Internal Server Error from the custom middleware.",
                                                                       null,
                                                                       null,
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