using CryptoAxus.Application.Contracts.Settings;
using CryptoAxus.Domain.Attributes;
using CryptoAxus.Infrastructure.Implementation.Repositories;
using CryptoAxus.Infrastructure.Implementation.Settings;
using MongoDB.Driver;

namespace CryptoAxus.Application.Features.Artist.Repositories;

public class ArtistRepositoryTestsData
{
    private readonly Mock<IRepository<ArtistDocument>> _mockRepository;
    private readonly Mock<IMongoDbSettings> _mockSettings;
    private readonly Mock<IMongoClient> _mockClient;
    private readonly Mock<IMongoDatabase> _mockDatabase;
    protected readonly ObjectId ArtistId;
    protected readonly string DatabaseName = "DummyDatabase";
    protected readonly string ConnectionString = "DummyConnectionString";
    private ArtistDocument mockArtistDocument;

    protected ArtistRepositoryTestsData()
    {
        _mockRepository = new Mock<IRepository<ArtistDocument>>();
        _mockSettings = new Mock<IMongoDbSettings>();
        _mockClient = new Mock<IMongoClient>();
        _mockDatabase = new Mock<IMongoDatabase>();
        ArtistId = new ObjectId("646d0779e663994062278fb8");
        mockArtistDocument = new ArtistDocument(new ObjectId("646d0779e663994062278fb8"),
                                                "Ben Affleck",
                                                "ben.affleck@google.com",
                                                "646d0779e663994062278fb8",
                                                "https://localhost:5000",
                                                "https://localhost:5000/swagger",
                                                "https://localhost:4000/wwwroot/images/profile/646d0779e663994062278fb8",
                                                "https://localhost:4000/wwwroot/images/cover/646d0779e663994062278fb8",
                                                "https://www.instagram.com/users?userId=646d0779e663994062278fb8",
                                                "https://www.twitter.com/users?userId=646d0779e663994062278fb8",
                                                new ObjectId("646d0779e663994062278fb8"));
    }

    public ArtistRepositoryTestsData SetupMockSettings()
    {
        IMongoDbSettings mockMongoDbSettings = new MongoDbSettings(DatabaseName, ConnectionString);

        _mockSettings.Setup(x => x.DatabaseName).Returns(mockMongoDbSettings.DatabaseName);
        _mockSettings.Setup(x => x.ConnectionString).Returns(mockMongoDbSettings.ConnectionString);

        return this;
    }

    public ArtistRepositoryTestsData SetupMockClient()
    {
        _mockClient.Setup(x => new MongoClient(ConnectionString));
        return this;
    }

    public ArtistRepositoryTestsData SetupMockDatabase()
    {
        List<ArtistDocument> artistDocuments = new List<ArtistDocument>();
        artistDocuments.Add(mockArtistDocument);
        Mock<IAsyncCursor<ArtistDocument>> mockCursor = new Mock<IAsyncCursor<ArtistDocument>>();
        //_mockDatabase.Setup(x => x.GetCollection<ArtistDocument>("Artist", null))
        //             .Returns(null);
        return this;
    }

    public ArtistRepositoryTestsData SetupMockRepositoryFindByIdAsync()
    {
        _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
                      .ReturnsAsync(mockArtistDocument);

        return this;
    }

    public Repository<ArtistDocument> Build()
    {
        return new Repository<ArtistDocument>(_mockSettings.Object, _mockClient.Object);
    }

    private string? GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType
                                         .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                                         .FirstOrDefault()!)?.CollectionName;
    }
}