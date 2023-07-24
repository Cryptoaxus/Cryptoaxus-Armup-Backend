namespace CryptoAxus.Application.Dto;

public class CreateArtistDto
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
    /// <example>0x507f191e810c19729de860ea</example>
    [JsonProperty("userId")]
    public int? UserId { get; set; }

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

    /// <summary>
    /// Artist profile cover image link
    /// </summary>
    /// <example>https://www.google.com/image?query=tom%20crusie</example>
    [JsonProperty("coverImageAddress")]
    public string? CoverImageAddress { get; set; }

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
    /// Created by user id
    /// </summary>
    /// <example>648cb3a86180aab54f00c3fc</example>
    [JsonProperty("createdBy")]
    public string? CreatedBy { get; set; }

    public CreateArtistDto()
    {
    }

    public CreateArtistDto(string? username,
                           string? email,
                           int? userId,
                           string? website,
                           string? bio,
                           string? profileImageAddress,
                           string? coverImageAddress,
                           string? instagram,
                           string? twitter,
                           string? createdBy)
    {
        Username = username;
        Email = email;
        UserId = userId;
        Website = website;
        Bio = bio;
        ProfileImageAddress = profileImageAddress;
        CoverImageAddress = coverImageAddress;
        Instagram = instagram;
        Twitter = twitter;
        CreatedBy = createdBy;
    }
}