namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Handler;

public class DeleteArtistByIdHandlerTests : DeleteArtistByIdTestsData
{
    [Fact]
    public async Task When_Artist_Id_Is_Provided_Expect_Delete_Result_Count_More_Than_Zero()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        var request = CreateRequest("647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldBeNull();
        response.ShouldBeOfType<DeleteArtistByIdResponse>();
    }

    [Fact]
    public async Task When_Artist_Id_Is_Provided_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryArtistNotFound().Build();

        var request = CreateRequest("647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.IsSuccessful.ShouldBe(false);
        response.Result.ShouldBeNull();
    }

    [Fact]
    public async Task When_Artist_Id_Is_Provided_Expect_Delete_Count_Zero()
    {
        // Arrange
        var sut = DeleteCountIsZero().Build();

        var request = CreateRequest("647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        response.IsSuccessful.ShouldBe(false);
        response.Result.ShouldBeNull();
    }
}