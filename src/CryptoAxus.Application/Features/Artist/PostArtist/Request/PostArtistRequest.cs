namespace CryptoAxus.Application.Features.Artist.PostArtist.Request;

public class PostArtistRequest : IRequest<PostArtistResponse>
{
    [JsonProperty("artist")]
    public ArtistDto Artist { get; set; }

    public PostArtistRequest(ArtistDto artist) => Artist = artist;
}