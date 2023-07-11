namespace CryptoAxus.Application.Features.Artist.GetOffersRecivedByArtist.Response;

public class GetOffersRecivedByArtistResponseExample : IExamplesProvider<GetOffersRecivedByArtistResponse>
{
    public GetOffersRecivedByArtistResponse GetExamples()
    { 
            return new GetOffersRecivedByArtistResponse(HttpStatusCode.OK, "Records found successfully.", new List<OffersDto>
         {
            new OffersDto(ObjectId.GenerateNewId(),
                          "6489ba6f704991467e824e5b",
                          Convert.ToDecimal(50.25),
                          5428,
                          285,
                          3,
                          2,
                          DateTime.UtcNow.AddHours(6),
                          ObjectId.GenerateNewId(),
                          DateTime.UtcNow.AddDays(-5),
                          ObjectId.GenerateNewId(),
                          false),

            new OffersDto(ObjectId.GenerateNewId(),
                          "6489ba6f704991467e824e5b",
                          Convert.ToDecimal(50.25),
                          5428,
                          286,
                          3,
                          2,
                          DateTime.UtcNow.AddHours(6),
                          ObjectId.GenerateNewId(),
                          DateTime.UtcNow.AddDays(-5),
                          ObjectId.GenerateNewId(),
                          false)
        }, new PaginationData(5, 1, 2, "http://cryptoaxus.com/api/artist/5428/offersMade"));
    }
}