namespace CryptoAxus.Application.Features.Artist.PostArtist.Response;

public class BadRequestPostArtistResponse : BaseResponse<ArtistDto>
{
    public BadRequestPostArtistResponse()
    {
    }

    public BadRequestPostArtistResponse(HttpStatusCode statusCode, string? message, ArtistDto result) : base(statusCode, message, result)
    {
    }
}