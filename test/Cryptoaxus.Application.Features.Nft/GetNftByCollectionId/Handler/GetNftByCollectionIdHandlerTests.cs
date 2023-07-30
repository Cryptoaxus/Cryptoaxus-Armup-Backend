namespace CryptoAxus.Application.Features.Nft.GetNftByCollectionId.Handler;

public class GetNftByCollectionIdHandlerTests : GetNftByCollectionIdTestsData
{
    [Theory]
    [InlineData("64c62ffa6397ada1ba0dc2e5")]
    [InlineData("64c62ffa6397ada1ba0dc2e6")]
    [InlineData("64c62ffa6397ada1ba0dc2e7")]
    public async Task When_Collection_Id_Is_Found_Expect_Ok_Result(string collectionId)
    {
        // Arrange
        var sut = SetupMockRepository(true).Build();
        var request = CreateRequest(collectionId);

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.ShouldBeOfType<GetNftByCollectionIdResponse>();
        response.Result.ShouldNotBeNull();
        response.Result.Count().ShouldBe(10);
    }

    [Theory]
    [InlineData("64c62ffa6397ada1ba0dc2e5")]
    [InlineData("64c62ffa6397ada1ba0dc2e6")]
    [InlineData("64c62ffa6397ada1ba0dc2e7")]
    public async Task When_Collection_Id_Is_Not_Found_Expect_Not_Found_Result(string collectionId)
    {
        // Arrange
        var sut = SetupMockRepository(false).Build();
        var request = CreateRequest(collectionId);

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.ShouldBeOfType<NotFoundGetNftByCollectionIdResponse>();
        response.Result.ShouldBeNull();
    }
}