namespace CryptoAxus.Application.Features.Artist.PostArtist.Response;

public class PostArtistResponse : BaseResponse<ArtistDto>
{
    public PostArtistResponse()
    {
    }

    public PostArtistResponse(HttpStatusCode statusCode, string? message, ArtistDto result) : base(statusCode, message, result)
    {
    }
}