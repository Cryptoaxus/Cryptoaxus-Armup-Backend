namespace CryptoAxus.Application.Features.Artist.PostArtist.Response;

public class ConflictPostArtistResponse : BaseResponse<ArtistDto>
{
    public ConflictPostArtistResponse()
    {
    }

    public ConflictPostArtistResponse(HttpStatusCode statusCode, string? message, ArtistDto? result) :
            base(statusCode, message, result)
    {
    }
}