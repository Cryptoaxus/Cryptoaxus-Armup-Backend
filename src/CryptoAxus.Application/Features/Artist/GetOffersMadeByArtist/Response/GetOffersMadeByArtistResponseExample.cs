namespace CryptoAxus.Application.Features.Artist.GetOffersMadeByArtist.Response;

public class GetOffersMadeByArtistResponseExample : IExamplesProvider<GetOffersMadeByArtistResponse>
{
    public GetOffersMadeByArtistResponse GetExamples()
    {
        return new GetOffersMadeByArtistResponse(HttpStatusCode.OK, "Records found successfully.", new List<OffersDto>
        {
            new OffersDto(ObjectId.GenerateNewId(),
                          "6489ba6f704991467e824e5b",
                          Convert.ToDecimal(50.25),
                          5428,
                          "0x2Fc6Bc584C44B71eB1C3c02d097612aed3CdA9f2",
                          DateTime.UtcNow.AddHours(6),
                          3,
                          2,
                          ObjectId.GenerateNewId(),
                          DateTime.UtcNow.AddDays(-5),
                          ObjectId.GenerateNewId(),
                          false),

            new OffersDto(ObjectId.GenerateNewId(),
                          "6489ba6f704991467e824e5b",
                          Convert.ToDecimal(50.25),
                          5428,
                          "0x2Fc6Bc584C44B71eB1C3c02d097612aed3CdA9f2",
                          DateTime.UtcNow.AddHours(6),
                          3,
                          2,
                          ObjectId.GenerateNewId(),
                          DateTime.UtcNow.AddDays(-5),
                          ObjectId.GenerateNewId(),
                          false)
        }, new PaginationData(5, 1, 2, "http://cryptoaxus.com/api/artist/5428/offersMade"));
    }
}
