namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;

public class BadRequestGetOffersMadeByArtistResponseExample : IExamplesProvider<BadRequestGetOffersMadeByArtistResponse>
{
    public BadRequestGetOffersMadeByArtistResponse GetExamples()
    {
        return new BadRequestGetOffersMadeByArtistResponse
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Invalid media type provided",
            PaginationData = null,
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}