namespace CryptoAxus.Application.Features.Nft.GetAllNft.Handler;

public class GetAllNftHandlerTests : GetAllNftTestData
{
    [Theory]
    [InlineData(1, 8)]
    [InlineData(2, 5)]
    [InlineData(2, 10)]
    public async Task When_Pagination_Parameters_Are_Provided_Expect_Ok_Result(int pageNumber, int pageSize)
    {
        // Arrange
        var sut = SetupMockCacheService().SetupMockRepository(pageNumber, pageSize).Build();
        var request = CreateRequest(pageNumber, pageSize);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldBeOfType<List<NftDto>>();
        response.Result.Count().ShouldBe(pageSize);
        response.PaginationData.ShouldNotBeNull();
    }

    [Theory]
    [InlineData(4, 10)]
    [InlineData(12, 15)]
    public async Task When_Nft_Does_Not_Exist_Expect_Not_Found_Result(int pageNumber, int pageSize)
    {
        // Arrange
        var sut = SetupMockCacheService().SetupMockRepositoryNotFound().Build();
        var request = CreateRequest(pageNumber, pageSize);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.IsSuccessful.ShouldBe(false);
        response.Message.ShouldBe("No nft record exists in the system.");
        response.Result.ShouldBeNull();
        response.PaginationData.ShouldBeNull();
    }

    [Theory]
    [InlineData(10, 25)]
    public async Task When_Cache_Exists_Return_Data_From_Cache(int pageNumber, int pageSize)
    {
        // Arrange
        var sut = SetupMockCacheServiceExists().Build();
        var request = CreateRequest(pageNumber, pageSize);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldBeOfType<List<NftDto>>();
        response.PaginationData?.TotalRecords.ShouldBe(100);
        response.PaginationData?.TotalPages.ShouldBe(4);
        response.PaginationData?.HasPrevious.ShouldBe(false);
        response.PaginationData?.HasNext.ShouldBe(true);
    }
}