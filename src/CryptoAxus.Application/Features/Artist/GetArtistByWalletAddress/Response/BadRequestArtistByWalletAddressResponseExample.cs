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
            Message = "Invalid media type provided",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}