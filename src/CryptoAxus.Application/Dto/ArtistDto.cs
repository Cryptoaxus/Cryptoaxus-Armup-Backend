namespace CryptoAxus.Application.Dto;

public class ArtistDto : BaseDto
{
    /// <summary>
    /// Artist username
    /// </summary>
    /// <example>junaid.sultan</example>
    [JsonProperty("username")]
    public string? Username { get; set; }

    /// <summary>
    /// Artist email
    /// </summary>
    /// <example>junaid.sultan@gmail.com</example>
    public string? Email { get; set; }

    public string? UserWalletAddress { get; set; }

    public string? Website { get; set; }

    public string? Bio { get; set; }

    public string? ProfileImageAddress { get; set; }

    public string? CoverImageAddress { get; set; }

    public string? Instagram { get; set; }

    public string? Twitter { get; set; }

    public ArtistDto()
    {
    }
}