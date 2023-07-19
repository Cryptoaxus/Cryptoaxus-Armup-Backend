namespace CryptoAxus.Application.Features.Artist.PatchArtist.Handler;

public class PatchArtistTests : PatchArtistTestsData
{
    [Fact]
    public async Task When_Artist_Is_Updated_Expect_Response_Of_No_Content()
    {
        // Arrange
        var sut = SetupMockRepository().SetupMockRepositoryUpdateOneAsync().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        response.Result.ShouldBeNull();
    }

    [Fact]
    public async Task When_Artist_Not_Found_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryArtistNotFound().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task When_Artist_Is_Updated_Expect_Bad_Request_Response()
    {
        // Arrange
        var sut = SetupMockRepository().SetupMockRepositoryUpdateOneAsync().SetupMockRepositoryReturnsBadRequest().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        response.Result.ShouldBeNull();
        response.IsSuccessful.ShouldBe(false);
    }
}