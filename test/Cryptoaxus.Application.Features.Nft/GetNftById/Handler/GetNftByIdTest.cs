using CryptoAxus.Application.Features.NFT.GetNftById.Response;

namespace CryptoAxus.Application.Features.Nft.GetNftById.Handler;

public class GetNftByIdTest : GetNftByIdTestData
{
    [Fact]
    public async Task When_Id_Is_Matched_Expect_Nft_Document_Returned()
    {
        //Arrange
        var sut = SetupMockRepository().Build();
        var request = CreateRequest();

        //Act
        var response = await sut.Handle(request);

        //Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldNotBeNull();
        response.Result.Name.ShouldBe("Test Nft");
        response.ShouldBeOfType(typeof(GetNftByIdResponse));
    }

    [Fact]
    public async Task When_Id_Is_Not_Matched_Expect_Not_Found_Result()
    {
        //Arrange
        var sut = SetupMockRepositoryReturnNull().Build();
        var request = CreateRequest();

        //Act
        var response = await sut.Handle(request);

        //Assert
        response.StatusCode.ShouldBe(HttpStatusCode.NotFound);
        response.IsSuccessful.ShouldBe(false);
        response.Result.ShouldBeNull();
        response.ShouldBeOfType(typeof(GetNftByIdResponse));
    }

    [Fact]
    public async Task When_Id_Is_Matched_Expect_Favorites_Likes_Count_Zero()
    {
        //Arrange
        var sut = SetupMockRepository().Build();
        var request = CreateRequest();

        //Act
        var response = await sut.Handle(request);

        //Assert
        response.StatusCode.ShouldBe(HttpStatusCode.OK);
        response.IsSuccessful.ShouldBe(true);
        response.Result.ShouldNotBeNull();
        response.ShouldBeOfType(typeof(GetNftByIdResponse));
        response.Result.Favorites.ShouldBeNull();
        response.Result.Likes.ShouldBeNull();
    }
}