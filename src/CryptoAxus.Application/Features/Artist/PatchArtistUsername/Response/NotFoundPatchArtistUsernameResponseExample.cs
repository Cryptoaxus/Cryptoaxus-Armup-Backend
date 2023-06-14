namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Response;

public class NotFoundPatchArtistUsernameResponseExample : IExamplesProvider<NotFoundPatchArtistUsernameResponse>
{
    public NotFoundPatchArtistUsernameResponse GetExamples()
    {
        return new NotFoundPatchArtistUsernameResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No record found against user wallet address: 0x507f191e810c19729de860ea",
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}