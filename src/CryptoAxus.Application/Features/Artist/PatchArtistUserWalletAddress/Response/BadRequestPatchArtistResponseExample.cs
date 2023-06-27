namespace CryptoAxus.Application.Features.Artist.PatchArtistUserWalletAddress.Response;

public class BadRequestPatchArtistResponseExample : IExamplesProvider<BadRequestPatchArtistResponse>
{
    public BadRequestPatchArtistResponse GetExamples()
    {
        return new BadRequestPatchArtistResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Invalid media type provided",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}