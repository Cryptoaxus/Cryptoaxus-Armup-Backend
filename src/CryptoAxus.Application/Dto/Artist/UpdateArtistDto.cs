using Microsoft.AspNetCore.Http;

namespace CryptoAxus.Application.Dto.Artist;

public class UpdateArtistDto
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
    /// Artist wallet address
    /// </summary>
    /// <example>5071</example>
    [JsonProperty("userId")]
    public int? UserId { get; set; }

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
    /// <example>https://www.google.com/image?query=tom%20crusie</example>
    [JsonProperty("profileImageAddress")]
    public string? ProfileImageAddress { get; set; }

    [JsonProperty("profileImage")]
    public IFormFile? ProfileImage { get; set; }

    /// <summary>
    /// Artist profile cover image link
    /// </summary>
    /// <example>https://www.google.com/image?query=tom%20crusie</example>
    [JsonProperty("coverImageAddress")]
    public string? CoverImageAddress { get; set; }

    [JsonProperty("coverImage")]
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

    /// <summary>
    /// Artist lastModifiedBy
    /// </summary>
    /// <example>junaid sultan</example>
    [JsonProperty("lastModifiedBy")]
    public string? LastModifiedBy { get; set; }

    /// <summary>
    /// Artist lastModifiedDate
    /// </summary>
    /// <example>20-10-2022</example>
    [JsonProperty("lastModifiedDate")]
    public DateTime? LastModifiedDate { get; set; }

    public UpdateArtistDto()
    {
    }

    public UpdateArtistDto(string? username,
                           string? email,
                           int? userId,
                           string? walletAddress,
                           string? website,
                           string? bio,
                           string? profileImageAddress,
                           IFormFile? profileImage,
                           string? coverImageAddress,
                           IFormFile? coverImage,
                           string? instagram,
                           string? twitter,
                           string? lastModifiedBy,
                           DateTime? lastModifiedDate)
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
        LastModifiedBy = lastModifiedBy;
        LastModifiedDate = lastModifiedDate;
    }
}