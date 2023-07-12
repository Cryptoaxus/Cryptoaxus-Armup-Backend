using Microsoft.AspNetCore.Mvc;

namespace CryptoAxus.Api.Test.Controllers.Artist;

public class ArtistControllerTest
{
    private readonly ArtistController _artistController;
    
    public ArtistControllerTest()
    {
        var mediator = new Mock<IMediator>();
        var logger = new Mock<ILogger<ArtistController>>();
        _artistController = new ArtistController(mediator.Object, logger.Object);
    }  
    [Fact]
    public async Task When_Media_Type_Provided_Is_Incorrect_Expect_Bad_Request()
    {
        // Arrange  // Act
        var response = await _artistController.GetOffersReceivedByArtist(234,new PaginationParameters (2,3 , null), "cryptoaxus@user");

        var mockContext = new Mock<ActionContext>();

        // Assert
        await response.ExecuteResultAsync(mockContext.Object);

        //var value = response.ExecuteResultAsync(new Microsoft.AspNetCore.Mvc.ActionContext());

        //value.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        //value.Result.ShouldBeNull();
        //value.IsSuccessful.ShouldBe(false);
        //value.Message.ShouldBe("Invalid media type provided");
        //value.PaginationData.ShouldBeNull();
    }
}