namespace CryptoAxus.Application.Features.Artist.PatchArtist.Response;

public class BadRequestPatchArtistResponse : BaseResponse<ArtistDto>
{
    public BadRequestPatchArtistResponse()
    {
    }

    public BadRequestPatchArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}