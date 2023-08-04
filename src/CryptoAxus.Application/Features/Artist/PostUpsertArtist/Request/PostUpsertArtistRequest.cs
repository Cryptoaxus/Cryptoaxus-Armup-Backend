namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Request;

public class PostUpsertArtistRequest : IRequest<PostUpsertArtistResponse>
{
    internal UpsertArtistDto Artist { get; set; }

    public PostUpsertArtistRequest(UpsertArtistDto artist) => Artist = artist;
}