namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class GetArtistByWalletAddressResponseExample : IExamplesProvider<GetArtistByWalletAddressResponse>
{
    public GetArtistByWalletAddressResponse GetExamples()
    {
        return new GetArtistByWalletAddressResponse(HttpStatusCode.OK, "Artist record found successfully", new ArtistDto());
    }
}