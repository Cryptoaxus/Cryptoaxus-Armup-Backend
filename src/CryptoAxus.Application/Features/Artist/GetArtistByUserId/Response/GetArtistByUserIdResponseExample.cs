namespace CryptoAxus.Application.Features.Artist.GetArtistByUserId.Response;

public class GetArtistByUserIdResponseExample : IExamplesProvider<GetArtistByUserIdResponse>
{
    public GetArtistByUserIdResponse GetExamples()
    {
        ArtistDto artistDto = new ArtistDto(ObjectId.GenerateNewId(),
                                            "tom.cruise",
                                            "tom.cruise@armup.com",
                                            5071,
                                            "0x507f191e810c19729de860ea",
                                            "https://www.google.com",
                                            "https://www.cryptaxus.com",
                                            "profileImage.gif",
                                            null,
                                            "coverImage.jpg",
                                            null,
                                            "https://www.insta.com",
                                            "https://www.twitter.com",
                                            ObjectId.GenerateNewId().ToString());

        return new GetArtistByUserIdResponse(HttpStatusCode.OK,
                                                    "Artist record found successfully",
                                                    artistDto);
    }
}