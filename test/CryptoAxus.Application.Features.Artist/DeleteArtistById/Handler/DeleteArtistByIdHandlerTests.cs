namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Handler;

public class DeleteArtistByIdHandlerTests : DeleteArtistByIdTestsData
{
    [Fact]
    public async Task When_Artist_Id_Is_Passed_Expect_Artist_Document_Is_Returned()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        var request = CreateQuery("647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        response.IsSuccessful.ShouldBe(true);
        response.Result?.Username.ShouldBe("Test-Id");
    }

    [Fact]
    public async Task When_Artist_Id_Is_Passed_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryArtistNotFound().Build();

        var request = CreateQuery("647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.IsSuccessful.ShouldBe(false);
        response.Result.ShouldBeNull();
    }

    [Fact]
    public async Task When_Artist_Id_Is_Passed_Expect_Bad_Request_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryReturnsBadRequest().Build();

        var request = CreateQuery("647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        response.IsSuccessful.ShouldBe(false);
        response.Result.ShouldBeNull();
    }

    [Fact]
    public async Task When_Request_Is_Null_Expect_Argument_Null_Exception()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        // Act // Assert
        try
        {
            var response = await sut.Handle(null);
        }
        catch (Exception exception)
        {
            exception.ShouldBeOfType<ArgumentNullException>();
        }
    }
}