namespace CryptoAxus.Application.Dto;

public class ArtistDto : BaseDto
{
    public string? Username { get; set; }

    public string? Email { get; set; }

    public string? UserWalletAddress { get; set; }

    public string? Website { get; set; }

    public string? Bio { get; set; }

    public string? ProfileImageAddress { get; set; }

    public string? CoverImageAddress { get; set; }

    public string? Instagram { get; set; }

    public string? Twitter { get; set; }

    public ArtistDto() : base()
    {
    }

    public ArtistDto(ObjectId id,
                     string? username = null,
                     string? email = null,
                     string? userWalletAddress = null,
                     string? website = null,
                     string? bio = null,
                     string? profileImageAddress = null,
                     string? coverImageAddress = null,
                     string? instagram = null,
                     string? twitter = null,
                     ObjectId? createdBy = null,
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