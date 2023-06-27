namespace CryptoAxus.Application.Features.Artist.PatchArtistUserWalletAddress.Response;

public class NotFoundPatchArtistResponse : BaseResponse<object>
{
    public NotFoundPatchArtistResponse()
    {
    }

    public NotFoundPatchArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}