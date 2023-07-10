namespace CryptoAxus.Application.Features.Artist.GetListOfOffersByArtist.Response;

public class BadRequestGetListOfOffersByArtistResponseExample : IExamplesProvider<BadRequestGetOffersRecivedByArtistResponse>
{
    public BadRequestGetOffersRecivedByArtistResponse GetExamples()
    {
        return new BadRequestGetOffersRecivedByArtistResponse()
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