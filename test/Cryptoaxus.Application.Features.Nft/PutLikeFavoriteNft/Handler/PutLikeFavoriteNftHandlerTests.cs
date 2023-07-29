namespace CryptoAxus.Application.Features.Nft.PutLikeFavoriteNft.Handler;

public class PutLikeFavoriteNftHandlerTests : PutLikeFavoriteNftTestsData
{
    [Theory]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a87")]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a88")]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a89")]
    public async Task When_Type_Is_Like_Expect_No_Content_Result(string nftId, string userId)
    {
        // Arrange
        var sut = SetupMockRepositoryFindOneAsync(true).SetupMockRepositoryUpdateOneAsync(true).Build();
        var request = CreateRequest(LikeFavoriteTypeEnum.Like, nftId, userId);

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        response.ShouldBeOfType<PutLikeFavoriteNftResponse>();
        response.Message.ShouldBe("Nft updated successfully.");
    }

    [Theory]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a87")]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a88")]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a89")]
    public async Task When_Type_Is_Favorite_Expect_No_Content_Result(string nftId, string userId)
    {
        // Arrange
        var sut = SetupMockRepositoryFindOneAsync(true).SetupMockRepositoryUpdateOneAsync(true).Build();
        var request = CreateRequest(LikeFavoriteTypeEnum.Favorite, nftId, userId);

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        response.ShouldBeOfType<PutLikeFavoriteNftResponse>();
        response.Message.ShouldBe("Nft updated successfully.");
    }

    [Theory]
    [InlineData(LikeFavoriteTypeEnum.Like, "64c544871e4e37e918060a86", "64c544871e4e37e918060a87")]
    [InlineData(LikeFavoriteTypeEnum.Like, "64c544871e4e37e918060a86", "64c544871e4e37e918060a88")]
    [InlineData(LikeFavoriteTypeEnum.Like, "64c544871e4e37e918060a86", "64c544871e4e37e918060a89")]
    [InlineData(LikeFavoriteTypeEnum.Favorite, "64c544871e4e37e918060a86", "64c544871e4e37e918060a87")]
    [InlineData(LikeFavoriteTypeEnum.Favorite, "64c544871e4e37e918060a86", "64c544871e4e37e918060a88")]
    [InlineData(LikeFavoriteTypeEnum.Favorite, "64c544871e4e37e918060a86", "64c544871e4e37e918060a89")]
    public async Task When_Nft_Does_Not_Exist_Expect_Not_Found_Result(LikeFavoriteTypeEnum type, string nftId, string userId)
    {
        // Arrange
        var sut = SetupMockRepositoryFindOneAsync(false).Build();
        var request = CreateRequest(type, nftId, userId);

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.ShouldBeOfType<NotFoundPutLikeFavoriteNftResponse>();
        response.Message.ShouldBe($"No nft exist against id: {nftId}.");
    }

    [Theory]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a87")]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a88")]
    [InlineData("64c544871e4e37e918060a86", "64c544871e4e37e918060a89")]
    public async Task When_Unable_To_Update_Expect_Bad_Request_Result(string nftId, string userId)
    {
        // Arrange
        var sut = SetupMockRepositoryFindOneAsync(true).SetupMockRepositoryUpdateOneAsync(false).Build();
        var request = CreateRequest(LikeFavoriteTypeEnum.Favorite, nftId, userId);

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        response.ShouldBeOfType<BadRequestPutLikeFavoriteNftResponse>();
        response.Message.ShouldBe("Unable to like/favorite nft.");
    }
}