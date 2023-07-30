using CryptoAxus.Application.Features.NFT.GetLikeFavoriteNftByArtists.Response;

namespace CryptoAxus.Application.Features.Nft.GetLikeFavoriteNftByArtist.Handler;

public class GetLikeFavoriteNftByArtistHandlerTests : GetLikeFavoriteNftByArtistTestsData
{
    [Fact]
    public async Task When_Artist_Id_Is_Matched_Expect_Ok_Result()
    {
        // Arrange
        var sut = SetupMockRepository(true).Build();
        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.ShouldBeOfType<GetLikeFavoriteNftByArtistResponse>();
        response.Result.ShouldNotBeNull();
        response.Result.FavoriteCount.ShouldBe(3);
        response.Result.LikedCount.ShouldBe(3);
    }

    [Fact]
    public async Task When_Artist_Id_Is_Not_Matched_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepository(false).Build();
        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.ShouldBeOfType<NotFoundGetLikeFavoriteNftByArtistResponse>();
    }
}