namespace CryptoAxus.Application.Features.Artist.PatchArtist.Response;

public class NotFoundPatchArtistResponse : BaseResponse<ArtistDto>
{
    public NotFoundPatchArtistResponse()
    {
    }

    public NotFoundPatchArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}