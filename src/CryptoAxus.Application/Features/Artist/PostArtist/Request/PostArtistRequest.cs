namespace CryptoAxus.Application.Features.Artist.PostArtist.Request;

public class PostArtistRequest : IRequest<PostArtistResponse>
{
    [JsonProperty("artist")]
    public CreateArtistDto Artist { get; set; }

    public PostArtistRequest(CreateArtistDto artist) => Artist = artist;
}