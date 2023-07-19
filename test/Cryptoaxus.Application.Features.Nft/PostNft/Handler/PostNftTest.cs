namespace CryptoAxus.Application.Features.Nft.PostNft.Handler;

public class PostNftTest : PostNftTestData
{
    [Fact]
    public async Task When_Nft_Dto_Is_Passed_Expect_Nft_Document_Created()
    {
        // Arrange
        var sut = SetupMockRepository().Build();
        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.ShouldBeOfType<PostNftResponse>();
        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(HttpStatusCode.Created);
        response.IsSuccessful.ShouldBe(true);
    }

    [Fact]
    public async Task When_Nft_Exists_Expect_Conflict_Response()
    {
        // Arrange
        var sut = SetupMockNftExists().Build();
        var request = CreateRequest();

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.ShouldBeOfType<PostNftResponse>();
        response.ShouldNotBeNull();
        response.StatusCode.ShouldBe(HttpStatusCode.Conflict);
        response.IsSuccessful.ShouldBe(false);
        response.Message.ShouldBe("Nft with same name already exists: Test Nft.");
    }
}