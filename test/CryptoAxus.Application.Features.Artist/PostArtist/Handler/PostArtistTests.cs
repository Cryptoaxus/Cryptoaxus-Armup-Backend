namespace CryptoAxus.Application.Features.Artist.PostArtist.Handler;

public class PostArtistTests : PostArtistTestsData
{
    [Fact]
    public async Task When_Artist_Data_Is_Provided_Expect_Created_Response()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        response.IsSuccessful.ShouldBe(true);
        response.Result?.Id.ShouldNotBeNull();
        response.Result.ShouldBeOfType<ArtistDto>();
    }

    [Fact]
    public async Task When_Artist_Already_Exist_Expect_Conflict_Response()
    {
        // Arrange
        var sut = MockRepositoryArtistExists().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Conflict);
        response.IsSuccessful.ShouldBe(false);
    }
}