namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class BadRequestArtistByWalletAddressResponse : BaseResponse<ArtistDto>
{
    public BadRequestArtistByWalletAddressResponse() : base()
    {
    }

    public BadRequestArtistByWalletAddressResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
    }
}