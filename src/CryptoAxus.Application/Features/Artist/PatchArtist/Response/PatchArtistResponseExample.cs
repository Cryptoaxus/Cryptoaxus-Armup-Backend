namespace CryptoAxus.Application.Features.Artist.PatchArtist.Response;

public class PatchArtistResponseExample : IExamplesProvider<PatchArtistResponse>
{
    public PatchArtistResponse GetExamples()
    {
        return new PatchArtistResponse
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = true,
            Links = null,
            Message = "Record updated successfully",
            Result = null,
            StatusCode = HttpStatusCode.NoContent
        };
    }
}