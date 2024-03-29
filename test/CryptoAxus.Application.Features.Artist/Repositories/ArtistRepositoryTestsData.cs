﻿namespace CryptoAxus.Application.Features.Artist.Repositories;

public class ArtistRepositoryTestsData
{
    private ArtistDocument _mockArtistDocument;
    private readonly Mock<IMongoCollection<ArtistDocument>> _mockCollection;
    private readonly Mock<ICryptoAxusContext> _mockContext;
    private readonly Mock<IAsyncCursor<ArtistDocument>> _mockCursor;
    private readonly IList<ArtistDocument> _list;


    protected ArtistRepositoryTestsData()
    {
        _mockArtistDocument = new ArtistDocument(new ObjectId("646d0779e663994062278fb8"),
                                                 "Ben Affleck",
                                                 "ben.affleck@google.com",
                                                 6460,
                                                 "walletAddress",
                                                 "https://localhost:5000",
                                                 "https://localhost:5000/swagger",
                                                 "https://localhost:4000/wwwroot/images/profile/646d0779e663994062278fb8",
                                                 "https://localhost:4000/wwwroot/images/cover/646d0779e663994062278fb8",
                                                 "https://www.instagram.com/users?userId=646d0779e663994062278fb8",
                                                 "https://www.twitter.com/users?userId=646d0779e663994062278fb8",
                                                 ObjectId.GenerateNewId().ToString());
        _mockCollection = new Mock<IMongoCollection<ArtistDocument>>();
        _mockContext = new Mock<ICryptoAxusContext>();
        _mockCursor = new Mock<IAsyncCursor<ArtistDocument>>();
        _list = new List<ArtistDocument>();
        _list.Add(_mockArtistDocument);
    }

    protected ArtistRepositoryTestsData SetupMockCollection()
    {
        _mockCollection.Object.InsertOne(_mockArtistDocument);
        return this;
    }

    public ArtistRepositoryTestsData SetupMockCursor()
    {
        _mockCursor.Setup(x => x.Current).Returns(_list);

        _mockCursor.SetupSequence(x => x.MoveNext(It.IsAny<CancellationToken>()))
                   .Returns(true)
                   .Returns(false);

        _mockCursor.SetupSequence(x => x.MoveNextAsync(It.IsAny<CancellationToken>()))
                   .Returns(Task.FromResult(true))
                   .Returns(Task.FromResult(false));

        return this;
    }

    public Repository<ArtistDocument> Build()
    {
        return new Repository<ArtistDocument>(_mockContext.Object);
    }

    //public ArtistRepositoryTestsData SetupMockSettings()
    //{
    //    IMongoDbSettings mockMongoDbSettings = new MongoDbSettings(DatabaseName, ConnectionString);

    //    _mockSettings.Setup(x => x.DatabaseName).Returns(mockMongoDbSettings.DatabaseName);
    //    _mockSettings.Setup(x => x.ConnectionString).Returns(mockMongoDbSettings.ConnectionString);

    //    return this;
    //}

    //public ArtistRepositoryTestsData SetupMockClient()
    //{
    //    _mockClient.Setup(x => new MongoClient(ConnectionString));
    //    return this;
    //}

    //public ArtistRepositoryTestsData SetupMockDatabase()
    //{
    //    List<ArtistDocument> artistDocuments = new List<ArtistDocument>();
    //    artistDocuments.Add(_mockArtistDocument);
    //    Mock<IAsyncCursor<ArtistDocument>> mockCursor = new Mock<IAsyncCursor<ArtistDocument>>();
    //    //_mockDatabase.Setup(x => x.GetCollection<ArtistDocument>("Artist", null))
    //    //             .Returns(null);
    //    return this;
    //}

    //public ArtistRepositoryTestsData SetupMockRepositoryFindByIdAsync()
    //{
    //    _mockRepository.Setup(x => x.FindByIdAsync(It.IsAny<ObjectId>()))
    //                  .ReturnsAsync(_mockArtistDocument);

    //    return this;
    //}

    //public Repository<ArtistDocument> Build()
    //{
    //    return new Repository<ArtistDocument>(_mockSettings.Object, _mockClient.Object);
    //}

    private string? GetCollectionName(Type documentType)
    {
        return ((BsonCollectionAttribute)documentType
                                         .GetCustomAttributes(typeof(BsonCollectionAttribute), true)
                                         .FirstOrDefault()!)?.CollectionName;
    }
}