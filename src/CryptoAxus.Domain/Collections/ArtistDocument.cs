namespace CryptoAxus.Domain.Collections;

[BsonCollection("Artists")]
public class ArtistDocument : BaseDocument
{
    [BsonElement(elementName: "username", Order = 2)]
    public string Username { get; set; }

    [BsonElement(elementName: "email", Order = 3)]
    public string Email { get; set; }

    [BsonElement(elementName: "userWalletAddress", Order = 4)]
    public string UserWalletAddress { get; set; }

    [BsonElement(elementName: "website", Order = 5)]
    public string Website { get; set; }

    [BsonElement(elementName: "bio", Order = 6)]
    public string Bio { get; set; }

    [BsonElement(elementName: "profileImageAddress", Order = 7)]
    public string ProfileImageAddress { get; set; }

    [BsonElement(elementName: "coverImageAddress", Order = 8)]
    public string CoverImageAddress { get; set; }

    [BsonElement(elementName: "instagram", Order = 9)]
    public string Instagram { get; set; }

    [BsonElement(elementName: "twitter", Order = 10)]
    public string Twitter { get; set; }

    public ArtistDocument() : base()
    {
    }

    public ArtistDocument(ObjectId id,
                          string username,
                          string email,
                          string userWalletAddress,
                          string website,
                          string bio,
                          string profileImageAddress,
                          string coverImageAddress,
                          string instagram,
                          string twitter,
                          ObjectId createdBy,
                          DateTime? lastModifiedDate = null,
                          ObjectId? lastModifiedBy = null,
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
        UserWalletAddress = userWalletAddress;
        Website = website;
        Bio = bio;
        ProfileImageAddress = profileImageAddress;
        CoverImageAddress = coverImageAddress;
        Instagram = instagram;
        Twitter = twitter;
        CreatedBy = createdBy;
        LastModifiedDate = lastModifiedDate;
        LastModifiedBy = lastModifiedBy;
        IsDeleted = isDeleted;
    }
}