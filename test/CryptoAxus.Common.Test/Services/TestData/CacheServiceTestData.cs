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

    public CacheServiceTestData SetupMockCacheService()
    {
        MockCacheService.Setup(x => x.GetAsync<string?>(It.IsAny<string>())).ReturnsAsync(StringCacheValue);
        return this;
    }

    public CacheServiceTestData SetupMockDistributedCacheService()
    {
        MockDistributedCache.Setup(x => x.GetStringAsync(It.IsAny<string>(), It.IsAny<CancellationToken>()))
                            .ReturnsAsync(StringCacheValue);
        return this;
    }

    public CacheService Build()
    {
        return new CacheService(MockDistributedCache.Object);
    }
}
