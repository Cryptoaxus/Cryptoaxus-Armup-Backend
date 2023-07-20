namespace CryptoAxus.Application.Features.Artist.PostArtist;

public class PostArtistTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;

    public PostArtistTestsData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
    }

    public PostArtistTestsData SetupMockRepository()
    {
        _mockRepository
               .Setup(x => x.Exists(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(false);

        _mockRepository.Setup(x => x.InsertOneAsync(It.IsAny<ArtistDocument>()))
                       .Returns(Task.CompletedTask);

        return this;
    }

    public PostArtistTestsData MockRepositoryArtistExists()
    {
        _mockRepository
               .Setup(x => x.Exists(It.IsAny<Expression<Func<ArtistDocument, bool>>>(), It.IsAny<CancellationToken>()))
               .ReturnsAsync(true);

        return this;
    }

    public PostArtistRequest CreateRequest()
    {
        return new PostArtistRequest(new CreateArtistDto("tom.cruise",
                                                         "tom.cruise@armup.com",
                                                         "0x51c330436F289192F43666e51Df72Ec06F66Dad9",
                                                         "https://www.tomcruise.com",
                                                         "Versatile actor",
                                                         "tom-cruise.png",
                                                         "tom-cruise-cover.png",
                                                         "https://www.instagram.com/tomcruise",
                                                         "https://www.twitter.com/tomcruise",
                                                         507191));
    }

    public PostArtistHandler Build()
    {
        return new PostArtistHandler(_mockRepository.Object);
    }
}