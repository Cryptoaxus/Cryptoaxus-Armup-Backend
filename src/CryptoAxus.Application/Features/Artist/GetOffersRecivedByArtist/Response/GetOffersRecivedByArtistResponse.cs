namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Response;

public class GetOffersRecivedByArtistResponse : PaginationResponse<List<OffersDto>>
{
    public GetOffersRecivedByArtistResponse()
    {
    }

    public GetOffersRecivedByArtistResponse(HttpStatusCode statusCode, string? message) : base(statusCode, message)
    {
    }

    public GetOffersRecivedByArtistResponse(HttpStatusCode statusCode, string? message, 
                                            List<OffersDto> result, PaginationData? paginationData) : base(statusCode, message)
    {
        Result = result;
        PaginationData = paginationData;
    }
}