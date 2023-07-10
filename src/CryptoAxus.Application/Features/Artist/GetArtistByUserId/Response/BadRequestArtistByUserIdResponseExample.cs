namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class BadRequestArtistByUserIdResponseExample : IExamplesProvider<BadRequestArtistByUserIdResponse>
{
    public BadRequestArtistByUserIdResponse GetExamples()
    {
        return new BadRequestArtistByUserIdResponse
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