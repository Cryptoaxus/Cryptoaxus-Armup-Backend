namespace CryptoAxus.Application.Features.Artist.PatchArtist.Response;

public class PatchArtistResponse : BaseResponse<ArtistDto>
{
    public PatchArtistResponse()
    {
    }

    public PatchArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}