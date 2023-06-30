namespace CryptoAxus.Common.Test.Services;

public class CacheServiceTest : CacheServiceTestData
{
    // Should return null value as the key is not set in redis

    [Fact]
    public async Task When_Cache_Returns_Null_Value()
    {
        // Arrange
        var sut = SetupMockCacheService().Build();

        // Act
        var value = await sut.GetAsync<string?>(StringCacheKey);

        // Assertion
        value.ShouldBeNull();
    }
}