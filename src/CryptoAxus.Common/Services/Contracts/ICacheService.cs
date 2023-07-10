namespace CryptoAxus.Common.Services.Contracts;

public interface ICacheService
{
    Task<T?> GetAsync<T>(string key);

    Task SetAsync(string key, string value);

    Task SetWithOptionsAsync<T>(string key, T value, DistributedCacheEntryOptions options);
}