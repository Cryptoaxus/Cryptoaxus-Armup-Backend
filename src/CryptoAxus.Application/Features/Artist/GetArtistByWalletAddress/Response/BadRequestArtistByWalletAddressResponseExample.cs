namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class BadRequestArtistByWalletAddressResponseExample : IExamplesProvider<BadRequestArtistByWalletAddressResponse>
{
    public BadRequestArtistByWalletAddressResponse GetExamples()
    {
        return new BadRequestArtistByWalletAddressResponse
        {
            ApiException = null,
            Links = null,
            Errors = null,
            IsSuccessful = false,
            Message = "Unable to delete artist against userWalletAddress: 647115d2b38bc8ea242beb01",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}