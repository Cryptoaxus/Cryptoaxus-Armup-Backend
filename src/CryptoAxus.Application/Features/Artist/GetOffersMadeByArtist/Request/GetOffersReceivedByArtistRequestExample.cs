namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Request;

public class GetOffersReceivedByArtistRequestExample : IExamplesProvider<GetOffersMadeByArtistRequest>
{
    public GetOffersMadeByArtistRequest GetExamples()
    {
        return new GetOffersMadeByArtistRequest(55667,
                                                new PaginationParameters(pageNumber: 1,
                                                                         pageSize: 10,
                                                                         fields: string.Empty));
    }
}