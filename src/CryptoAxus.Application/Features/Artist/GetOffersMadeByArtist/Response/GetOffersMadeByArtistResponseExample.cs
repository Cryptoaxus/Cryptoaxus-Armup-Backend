namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;

public class GetOffersMadeByArtistResponseExample : IExamplesProvider<GetOffersMadeByArtistResponse>
{
    public GetOffersMadeByArtistResponse GetExamples()
    {
        return new GetOffersMadeByArtistResponse(HttpStatusCode.OK, "Records found successfully.", new List<OffersDtoWithLinks>
        {
            new OffersDtoWithLinks(ObjectId.GenerateNewId(),
                                   "6489ba6f704991467e824e5b",
                                   Convert.ToDecimal(50.25),
                                   5428,
                                   2658,
                                   3,
                                   2,
                                   DateTime.UtcNow.AddHours(6),
                                   null,
                                   ObjectId.GenerateNewId().ToString(),
                                   DateTime.UtcNow.AddDays(-5),
                                   ObjectId.GenerateNewId().ToString()),

            new OffersDtoWithLinks(ObjectId.GenerateNewId(),
                                   "6489ba6f704991467e824e5b",
                                   Convert.ToDecimal(50.25),
                                   5428,
                                   2658,
                                   3,
                                   2,
                                   DateTime.UtcNow.AddHours(6),
                                   null,
                                   ObjectId.GenerateNewId().ToString(),
                                   DateTime.UtcNow.AddDays(-5),
                                   ObjectId.GenerateNewId().ToString())
        }, new PaginationData(5, 1, 2, "http://cryptoaxus.com/api/artist/5428/offersMade"));
    }
}
