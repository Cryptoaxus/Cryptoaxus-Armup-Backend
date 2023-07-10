namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Request;

public class GetOffersRecivedByArtistRequestExample : IExamplesProvider<GetOffersRecivedByArtistRequest>
{
    public GetOffersRecivedByArtistRequest GetExamples()
    {
        return new GetOffersRecivedByArtistRequest(55667,
                                                new PaginationParameters(pageNumber: 1,
                                                                         pageSize: 10,
                                                                         fields: string.Empty));
    }
}