using CryptoAxus.Common.Services.Contracts;
using CryptoAxus.Common.Services.Implementation;
using Microsoft.Extensions.Caching.Distributed;
using Moq;

namespace CryptoAxus.Common.Test.Services.TestData;

public class CacheServiceTestData
{
    // Contains the test data
    protected readonly string StringCacheValue = "Test cache value";
    protected readonly string StringCacheKey = "stringCacheKey";

    public Mock<ICacheService> MockCacheService { get; }
    public Mock<IDistributedCache> MockDistributedCache { get; }

    public CacheServiceTestData()
    {
        MockCacheService = new Mock<ICacheService>();
        MockDistributedCache = new Mock<IDistributedCache>();
    }

    public CacheServiceTestData SetupMockCacheService(string key)
    {
        MockCacheService.Setup(x => x.GetAsync<string?>(key)).ReturnsAsync(StringCacheValue);
        return this;
    }

    public CacheServiceTestData SetupMockDistributedCacheService(string key)
    {
        MockDistributedCache.Setup(x => x.GetStringAsync(key, default)).ReturnsAsync(StringCacheValue);
        return this;
    }

    public CacheService Build()
    {
        return new CacheService(MockDistributedCache.Object);
    }
}
