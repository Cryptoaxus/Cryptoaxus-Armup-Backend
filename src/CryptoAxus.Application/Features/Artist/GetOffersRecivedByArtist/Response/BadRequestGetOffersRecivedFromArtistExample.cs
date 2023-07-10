namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Response;

public class BadRequestGetOffersRecivedFromArtistExample : IExamplesProvider<BadRequestGetOffersRecivedByArtistResponse>
{
    public BadRequestGetOffersRecivedByArtistResponse GetExamples()
    {
        return new BadRequestGetOffersRecivedByArtistResponse()
        {
            ApiException = null,
            Errors = null,
            IsSuccessful = false,
            Links = null,
            Message = "Bad request unable to update username",
            Result = null,
            StatusCode = HttpStatusCode.BadRequest
        };
    }
}