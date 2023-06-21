namespace CryptoAxus.Application.Features.Artist.GetArtistByWalletAddress.Response;

public class GetArtistByWalletAddressResponseExample : IExamplesProvider<GetArtistByWalletAddressResponse>
{
    public GetArtistByWalletAddressResponse GetExamples()
    {
        ArtistDto artistDto = new ArtistDto(ObjectId.GenerateNewId(), 
                                            "tom.cruise", 
                                            "tom.cruise@armup.com", 
                                            "0x507f191e810c19729de860ea",
                                            "https://www.google.com",
                                            "https://www.cryptaxus.com",
                                            "profileimage.gif",
                                            "coverimage.jpg",
                                            "https://www.insta.com",
                                            "https://www.twitter.com",
                                            ObjectId.GenerateNewId().ToString());

        return new GetArtistByWalletAddressResponse(HttpStatusCode.OK, 
                                                    "Artist record found successfully", 
                                                    artistDto);                                                                  
    }
}