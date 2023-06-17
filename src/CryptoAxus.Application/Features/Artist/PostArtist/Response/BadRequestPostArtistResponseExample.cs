namespace CryptoAxus.Application.Features.Artist.PostArtist.Response;

public class BadRequestPostArtistResponseExample : IExamplesProvider<BadRequestPostArtistResponse>
{
    public BadRequestPostArtistResponse GetExamples()
    {
        return new BadRequestPostArtistResponse
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Bad request unable to add artist",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}