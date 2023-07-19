namespace CryptoAxus.Application.Features.Artist.PatchArtist.Response;

public class NotFoundPatchArtistResponseExample : IExamplesProvider<NotFoundPatchArtistResponse>
{
    public NotFoundPatchArtistResponse GetExamples()
    {
        return new NotFoundPatchArtistResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No record found against id: 0x647115d2b38bc8ea242beb01",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}