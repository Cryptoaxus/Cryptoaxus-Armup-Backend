namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;

public class BadRequestGetOffersMadeByArtistResponse : PaginationResponse<List<OffersDtoWithLinks>>
{
    public BadRequestGetOffersMadeByArtistResponse()
    {
    }

    public BadRequestGetOffersMadeByArtistResponse(HttpStatusCode statusCode,
                                                   string? message,
                                                   List<string> errors) :
                                                   base(statusCode,
                                                        message,
                                                        errors)
    {
    }
}