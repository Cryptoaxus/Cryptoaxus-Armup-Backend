namespace CryptoAxus.Application.Features.Nft.PutNft.Handler;

public class PutNftHandlerTests : PutNftTestsData
{
    [Fact]
    public async Task When_Nft_Is_Updated_Expect_Response_Of_No_Content()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NoContent);
        response.Result.ShouldNotBeNull();
    }

    [Fact]
    public async Task When_Nft_Is_Not_Found_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryNotFound().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
    }

    [Fact]
    public async Task When_Nft_Is_Not_Updated_Expect_Bad_Request_Response()
    {
        // Arrange
        var sut = SetupMockRepositoryUnableToUpdate().Build();

        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        response.Result.ShouldBeNull();
        response.IsSuccessful.ShouldBe(false);
    }
}