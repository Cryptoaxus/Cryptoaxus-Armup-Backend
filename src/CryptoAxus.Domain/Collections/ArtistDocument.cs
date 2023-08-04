namespace CryptoAxus.Domain.Collections;

[BsonCollection("Artists")]
public class ArtistDocument : BaseDocument
{
    [BsonElement(elementName: "username", Order = 2)]
    public string Username { get; set; }

    [BsonElement(elementName: "email", Order = 3)]
    public string Email { get; set; }

    [BsonElement(elementName: "userId", Order = 4)]
    public int? UserId { get; set; }

    [BsonElement(elementName: "walletAddress", Order = 5)]
    public string? WalletAddress { get; set; }

    [BsonElement(elementName: "website", Order = 6)]
    public string Website { get; set; }

    [BsonElement(elementName: "bio", Order = 7)]
    public string Bio { get; set; }

    [BsonElement(elementName: "profileImageAddress", Order = 8)]
    public string ProfileImageAddress { get; set; }

    [BsonElement(elementName: "coverImageAddress", Order = 9)]
    public string CoverImageAddress { get; set; }

    [BsonElement(elementName: "instagram", Order = 10)]
    public string Instagram { get; set; }

    [BsonElement(elementName: "twitter", Order = 11)]
    public string Twitter { get; set; }

    public ArtistDocument() : base()
    {
    }

    public ArtistDocument(ObjectId id,
                          string username,
                          string email,
                          int? userId,
                          string walletAddress,
                          string website,
                          string bio,
                          string profileImageAddress,
                          string coverImageAddress,
                          string instagram,
                          string twitter,
                          string createdBy,
                          DateTime? lastModifiedDate = null,
                          string? lastModifiedBy = null,
                          bool isDeleted = false)
                          : base(id,
                                 createdBy,
                                 lastModifiedDate,
                                 lastModifiedBy,
                                 isDeleted)
    {
        Id = id;
        Username = username;
        Email = email;
        UserId = userId;
        WalletAddress = walletAddress;
        Website = website;
        Bio = bio;
        ProfileImageAddress = profileImageAddress;
        CoverImageAddress = coverImageAddress;
        Instagram = instagram;
        Twitter = twitter;
    }
}