namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Request;

public class GetOffersReceivedByArtistRequest : IRequest<GetOffersReceivedByArtistResponse>
{
    internal int UserId { get; private set; }

    internal PaginationParameters PaginationParameters { get; set; }

    public GetOffersReceivedByArtistRequest(int userId, PaginationParameters paginationParameters) =>
                                           (UserId, PaginationParameters) =
                                           (userId, paginationParameters);
}