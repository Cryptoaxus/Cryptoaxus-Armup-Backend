namespace CryptoAxus.Application;

public static class ServiceExtensions
{
    public static void AddApplicationLayer(this IServiceCollection services)
    {
        services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
    }
}