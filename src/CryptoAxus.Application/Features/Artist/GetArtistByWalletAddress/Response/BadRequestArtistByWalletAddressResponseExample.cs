namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class BadRequestArtistByWalletAddressResponseExample : IExamplesProvider<BadRequestArtistByWalletAddressResponse>
{
    public BadRequestArtistByWalletAddressResponse GetExamples()
    {
        return new BadRequestArtistByWalletAddressResponse(HttpStatusCode.BadRequest, "Invalid media type provided");
    }
}