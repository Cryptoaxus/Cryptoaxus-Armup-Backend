namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;

public class BadRequestPatchArtistUsernameResponse : BaseResponse<object>
{
    public BadRequestPatchArtistUsernameResponse()
    {
    }

    public BadRequestPatchArtistUsernameResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}