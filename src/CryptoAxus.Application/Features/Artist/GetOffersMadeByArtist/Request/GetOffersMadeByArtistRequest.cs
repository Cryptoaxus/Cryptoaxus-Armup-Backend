namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Request;

public class GetOffersMadeByArtistRequest : IRequest<GetOffersMadeByArtistResponse>
{
    internal int UserId { get; set; }

    internal PaginationParameters PaginationParameters { get; set; }

    public GetOffersMadeByArtistRequest(int userId, PaginationParameters paginationParameters) =>
                                       (UserId, PaginationParameters) =
                                       (userId, paginationParameters);
}