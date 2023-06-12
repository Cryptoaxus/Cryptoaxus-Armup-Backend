namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;

public class PatchArtistUsernameResponse : BaseResponse<object>
{
    public PatchArtistUsernameResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}