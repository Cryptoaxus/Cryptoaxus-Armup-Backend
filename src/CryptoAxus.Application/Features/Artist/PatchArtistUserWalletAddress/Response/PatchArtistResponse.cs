namespace CryptoAxus.Application.Features.Artist.PatchArtistUserWalletAddress.Response;

public class PatchArtistResponse : BaseResponse<object>
{
    public PatchArtistResponse()
    {
    }

    public PatchArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }
}