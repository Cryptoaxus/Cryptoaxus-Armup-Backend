namespace CryptoAxus.Application.Features.Artist.PatchArtistUserWalletAddress.Response;

public class BadRequestPatchArtistResponse : BaseResponse<object>
{
    public BadRequestPatchArtistResponse()
    {
    }

    public BadRequestPatchArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}