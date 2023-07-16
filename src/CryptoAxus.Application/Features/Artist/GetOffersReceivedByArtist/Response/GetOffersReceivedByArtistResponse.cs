namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Response;

public class GetOffersReceivedByArtistResponse : PaginationResponse<List<OffersDtoWithLinks>>
{
    public GetOffersReceivedByArtistResponse()
    {
    }

    public GetOffersReceivedByArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetOffersReceivedByArtistResponse(HttpStatusCode statusCode, string? message, 
                                             List<OffersDtoWithLinks> result, PaginationData? paginationData) : base(statusCode, message)
    {
        Result = result;
        PaginationData = paginationData;
    }
}