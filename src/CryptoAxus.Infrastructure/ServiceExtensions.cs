namespace CryptoAxus.Infrastructure;

public static class ServiceExtensions
{
    public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

        services.AddSingleton<IMongoDbSettings>(provider => provider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

        services.AddScoped<IMongoClient>(ctx =>
        {
            var settings = ctx.GetRequiredService<IMongoDbSettings>();
            return new MongoClient(settings.ConnectionString);
        });

        services.AddScoped<ICryptoAxusContext, CryptoAxusContext>();

        // Repositories
        services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
    }
}