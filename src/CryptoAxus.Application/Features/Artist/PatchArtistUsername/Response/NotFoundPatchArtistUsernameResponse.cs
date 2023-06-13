namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;

public class NotFoundPatchArtistUsernameResponse : BaseResponse<object>
{
    public NotFoundPatchArtistUsernameResponse()
    {
    }

    public NotFoundPatchArtistUsernameResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}