namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;

public class GetOffersMadeByArtistResponse : PaginationResponse<List<OffersDto>>
{
    public GetOffersMadeByArtistResponse()
    {
    }

    public GetOffersMadeByArtistResponse(HttpStatusCode statusCode, string message) : base(statusCode, message)
    {
    }

    public GetOffersMadeByArtistResponse(HttpStatusCode statusCode,
                                         string message,
                                         List<OffersDto> result,
                                         PaginationData paginationData) :
                                         this(statusCode, message)
    {
        Result = result;
        PaginationData = paginationData;
    }
}
