namespace CryptoAxus.Application.Features.Artist.PostArtist.Response;

public class ConflictPostArtistResponseExample : IExamplesProvider<ConflictPostArtistResponse>
{
    public ConflictPostArtistResponse GetExamples()
    {
        return new ConflictPostArtistResponse
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Artist with same wallet address already exists",
            Result = null,
            StatusCode = HttpStatusCode.Conflict
        };
    }
}