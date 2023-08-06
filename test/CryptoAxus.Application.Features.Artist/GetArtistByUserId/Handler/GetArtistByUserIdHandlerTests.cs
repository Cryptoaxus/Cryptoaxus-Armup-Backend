namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId.Handler;

public class GetArtistByUserIdHandlerTests : GetArtistByUserIdTestData
{
    [Fact]
    public async Task When_Artist_User_Id_Is_Passed_Expect_Artist_Document_Is_Returned()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        var request = CreateRequest(6471);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result?.Username.ShouldBe("testUsername");
    }

    [Fact]
    public async Task When_Artist_User_Id_Is_Passed_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryNotFound().Build();

        var request = CreateRequest(6471);

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.IsSuccessful.ShouldBe(false);
        response.Result.ShouldBeNull();
    }
}