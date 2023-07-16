namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Response;

public class BadRequestGetOffersReceivedByArtistResponse : PaginationResponse<List<OffersDtoWithLinks>>
{
    public BadRequestGetOffersReceivedByArtistResponse() 
    {
    }
    public BadRequestGetOffersReceivedByArtistResponse(HttpStatusCode statusCode,
                                                       string? message,
                                                       List<string> errors) :
                                                       base(statusCode,
                                                            message,
                                                            errors)
    {
    }
}