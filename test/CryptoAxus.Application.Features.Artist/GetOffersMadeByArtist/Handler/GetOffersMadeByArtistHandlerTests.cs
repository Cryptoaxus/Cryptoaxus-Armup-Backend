namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Handler;

public class GetOffersMadeByArtistHandlerTests : GetOffersMadeByArtistHandlerTestData
{
    [Theory]
    [InlineData(285, 1, 8)]
    [InlineData(285, 2, 5)]
    [InlineData(285, 2, 10)]
    public async Task When_UserId_And_Pagination_Is_Provided_Expect_Ok_Result(int userId, int pageNumber, int pageSize)
    {
        // Arrange
        var sut = SetupMockCacheService().SetupMockRepository(pageNumber, pageSize).Build();
        var request = CreateRequest(userId, pageNumber, pageSize);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldBeOfType<List<OffersDtoWithLinks>>();
        response.Result.Count.ShouldBe(pageSize);
        response.PaginationData.ShouldNotBeNull();
    }

    [Theory]
    [InlineData(285, 4, 10)]
    [InlineData(3590, 12, 15)]
    public async Task When_UserId_Is_Not_Found_Expect_Not_Found_Result(int userId, int pageNumber, int pageSize)
    {
        // Arrange
        var sut = SetupMockCacheService().SetupMockRepositoryNotFound().Build();
        var request = CreateRequest(userId, pageNumber, pageSize);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.IsSuccessful.ShouldBe(false);
        response.Message.ShouldBe($"No records found against userId: {userId}.");
        response.Result.ShouldBeNull();
        response.PaginationData.ShouldBeNull();
    }

    [Theory]
    [InlineData(62490, 10, 25)]
    public async Task When_Cache_Exists_Return_Data_From_Cache(int userId, int pageNumber, int pageSize)
    {
        // Arrange
        var sut = SetupMockCacheServiceExists().Build();
        var request = CreateRequest(userId, pageNumber, pageSize);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldBeOfType<List<OffersDtoWithLinks>>();
        response.PaginationData?.TotalRecords.ShouldBe(100);
        response.PaginationData?.TotalPages.ShouldBe(4);
        response.PaginationData?.HasPrevious.ShouldBe(false);
        response.PaginationData?.HasNext.ShouldBe(true);
    }
}