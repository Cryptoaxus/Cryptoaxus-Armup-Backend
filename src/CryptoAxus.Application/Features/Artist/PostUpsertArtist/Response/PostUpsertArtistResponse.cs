namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Response;

public class PostUpsertArtistResponse : BaseResponse<ArtistDto>
{
    public PostUpsertArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public PostUpsertArtistResponse(HttpStatusCode statusCode, string? message, ArtistDto artist) : this(statusCode, message) => Result = artist;
}