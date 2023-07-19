namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;

public class NotFoundGetOffersMadeByArtistResponseExample : IExamplesProvider<NotFoundGetOffersMadeByArtistResponse>
{
    public NotFoundGetOffersMadeByArtistResponse GetExamples()
    {
        return new NotFoundGetOffersMadeByArtistResponse
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "No records found against userId: 6471",
            PaginationData = null,
            Result = null,
            StatusCode = HttpStatusCode.NotFound
        };
    }
}