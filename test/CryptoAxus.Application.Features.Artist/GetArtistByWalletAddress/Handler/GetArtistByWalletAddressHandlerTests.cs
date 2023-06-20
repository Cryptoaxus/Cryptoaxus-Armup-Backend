namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Handler;

public class GetArtistByWalletAddressHandlerTests : GetArtistByWalletAddressTestData
{
    [Fact]
    public async Task When_Artist_WalletAddress_Is_Passed_Expect_Artist_Document_Is_Returned()
    {
        // Arrange
        var sut = SetupMockRepository().Build();

        var request = CreateRequest("0x647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result?.Username.ShouldBe("testUsername");
    }

    [Fact]
    public async Task When_Artist_WalletAddress_Is_Passed_Expect_Not_Found_Result()
    {
        // Arrange
        var sut = SetupMockRepositoryNotFound().Build();

        var request = CreateRequest("0x647115d2b38bc8ea242beb01");

        // Act
        var response = await sut.Handle(request);

        // Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
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