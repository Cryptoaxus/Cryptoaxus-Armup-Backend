namespace CryptoAxus.Application.Features.Artist.GetOffersReceivedByArtist.Request;

public class GetOffersReceivedByArtistRequestExample : IExamplesProvider<GetOffersReceivedByArtistRequest>
{
    public GetOffersReceivedByArtistRequest GetExamples()
    {
        return new GetOffersReceivedByArtistRequest(55667,
                                                    new PaginationParameters(pageNumber: 1,
                                                                             pageSize: 10,
                                                                             fields: string.Empty));
    }
}