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

    [Theory]
    [InlineData(4258, 1, 5, "", "application+html")]
    [InlineData(256, 4, 10, "", "application_vnd.hateoas+json")]
    [InlineData(256, 4, 10, "", "application_json")]
    public async Task When_Invalid_Media_Type_Is_Provided_Expect_Bad_Request_Response(int userId,
                                                                                      int pageNumber,
                                                                                      int pageSize,
                                                                                      string fields,
                                                                                      string mediaType)
    {
        var result = await _artistController.OffersMadeByArtist(userId, new PaginationParameters(pageNumber, pageSize, fields), mediaType);

        var response = (BadRequestObjectResult)result;

        var value = (BadRequestGetOffersMadeByArtistResponse)response.Value!;

        result.ShouldNotBeNull();

        response.ShouldNotBeNull();

        response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);

        value.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

        value.IsSuccessful.ShouldBe(false);

        value.Result.ShouldBeNull();

        value.Errors?.Count.ShouldBeGreaterThan(0);

        value.Errors?.ShouldContain("Invalid media type provided");
    }

    [Theory]
    [InlineData(5060, 2, 9, "", "application+html")]
    [InlineData(290, 7, 4, "", "application_vnd.hateoas+json")]
    [InlineData(240, 3, 8, "", "application_json")]
    public async Task When_Invalid_Media_Type_Is_Provided_To_Offers_Recieved_By_Artist_Expect_Bad_Request_Response(int userId,
                                                                                                                   int pageNumber,
                                                                                                                   int pageSize,
                                                                                                                   string fields,
                                                                                                                   string mediaType)
    {
        var result = await _artistController.GetOffersReceivedByArtist(userId, new PaginationParameters(pageNumber, pageSize, fields), mediaType);

        var response = (BadRequestObjectResult)result;

        var value = (BadRequestGetOffersReceivedByArtistResponse)response.Value!;

        result.ShouldNotBeNull();

        response.ShouldNotBeNull();

        response.StatusCode.ShouldBe((int)HttpStatusCode.BadRequest);

        value.StatusCode.ShouldBe(HttpStatusCode.BadRequest);

        value.IsSuccessful.ShouldBe(false);

        value.Result.ShouldBeNull();

        value.Errors?.Count.ShouldBeGreaterThan(0);

        value.Errors?.ShouldContain("Invalid media type provided");
    }
}