namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Request;

public class GetOffersRecivedByArtistRequest : IRequest<GetOffersRecivedByArtistResponse>
{
    internal int UserId { get; private set; }

    internal PaginationParameters PaginationParameters { get; set; }

    public GetOffersRecivedByArtistRequest(int userId, PaginationParameters paginationParameters) =>
                                          (UserId, PaginationParameters) =
                                          (userId, paginationParameters);
}