namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;

public class PatchArtistUsernameResponseExample : IExamplesProvider<PatchArtistUsernameResponse>
{
    public PatchArtistUsernameResponse GetExamples()
    {
        return new PatchArtistUsernameResponse
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = true,
            Links = null,
            Message = "Artist username updated successfully",
            Result = null,
            StatusCode = HttpStatusCode.NoContent
        };
    }
}