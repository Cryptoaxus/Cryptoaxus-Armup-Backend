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
}