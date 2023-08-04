using Microsoft.AspNetCore.Http;

namespace CryptoAxus.Application.Dto.Artist;

public class ArtistDto : BaseDto
{
    /// <summary>
    /// Artist username
    /// </summary>
    /// <example>tom.cruise</example>
    [JsonProperty("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Artist email
    /// </summary>
    /// <example>tomcruise@gmail.com</example>
    [JsonProperty("email")]
    public string? Email { get; set; }

    /// <summary>
    /// Artist user id
    /// </summary>
    /// <example>1428</example>
    [JsonProperty("userId")]
    public int? UserId { get; set; }

    /// <summary>
    /// Artist wallet address
    /// </summary>
    /// <example>0x507f191e810c19729de860ea</example>
    [JsonProperty("walletAddress")]
    public string? WalletAddress { get; set; }

    /// <summary>
    /// Artist website url
    /// </summary>
    /// <example>https://www.tomcruise.com</example>
    [JsonProperty("website")]
    public string? Website { get; set; }

    /// <summary>
    /// Artist bio details
    /// </summary>
    /// <example>Versatile actor</example>
    [JsonProperty("bio")]
    public string? Bio { get; set; }

    /// <summary>
    /// Artist profile image link
    /// </summary>
    /// <example>profile-image.png</example>
    [JsonProperty("profileImageAddress")]
    public string? ProfileImageAddress { get; set; }

    /// <summary>
    /// Profile image
    /// </summary>
    public IFormFile? ProfileImage { get; set; }

    /// <summary>
    /// Artist profile cover image link
    /// </summary>
    /// <example>cover-image.png</example>
    [JsonProperty("coverImageAddress")]
    public string? CoverImageAddress { get; set; }

    /// <summary>
    /// Cover image
    /// </summary>
    public IFormFile? CoverImage { get; set; }

    /// <summary>
    /// Instagram profile link
    /// </summary>
    /// <example>https://www.instagram.com/tom-cruise</example>
    [JsonProperty("instagram")]
    public string? Instagram { get; set; }

    /// <summary>
    /// Twitter profile link
    /// </summary>
    /// <example>https://www.twitter.com/tom-cruise</example>
    [JsonProperty("twitter")]
    public string? Twitter { get; set; }

    public ArtistDto() : base()
    {
    }

    public ArtistDto(ObjectId id,
                     string? username = null,
                     string? email = null,
                     int? userId = null,
                     string? walletAddress = null,
                     string? website = null,
                     string? bio = null,
                     string? profileImageAddress = null,
                     IFormFile? profileImage = null,
                     string? coverImageAddress = null,
                     IFormFile? coverImage = null,
                     string? instagram = null,
                     string? twitter = null,
                     string? createdBy = null,
                     DateTime? lastModifiedDate = null,
                     string? lastModifiedBy = null,
                     bool isDeleted = false)
                     : base(id,
                            createdBy,
                            lastModifiedDate,
                            lastModifiedBy,
                            isDeleted)
    {
        Username = username;
        Email = email;
        UserId = userId;
        WalletAddress = walletAddress;
        Website = website;
        Bio = bio;
        ProfileImageAddress = profileImageAddress;
        ProfileImage = profileImage;
        CoverImageAddress = coverImageAddress;
        CoverImage = coverImage;
        Instagram = instagram;
        Twitter = twitter;
    }
}