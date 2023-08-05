using CryptoAxus.Application.Features.NftCollection.PostNftCollection.Response;

namespace CryptoAxus.Application.Features.Nft.PostNftCollection.Handler;

public class PostNftCollectionHandlerTests : PostNftCollectionTestsData
{
    [Fact]
    public async Task When_Collection_Name_Exist_Expect_Conflict_Response()
    {
        // Arrange
        var sut = SetupMockRepositoryExist(true).Build();
        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Conflict);
        response.Result.ShouldBeNull();
    }

    [Fact]
    public async Task When_Collection_Name_Does_Not_Exist_Expect_Created_Response()
    {
        // Arrange
        var sut = SetupMockRepositoryExist(false).SetupMockRepositoryInsert().Build();
        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request, default);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        response.Result.ShouldNotBeNull();
        response.ShouldBeOfType<PostNftCollectionResponse>();
    }
}