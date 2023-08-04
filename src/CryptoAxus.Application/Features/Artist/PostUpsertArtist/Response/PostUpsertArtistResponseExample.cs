namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Response;

public class PostUpsertArtistResponseExample : IExamplesProvider<PostUpsertArtistResponse>
{
    public PostUpsertArtistResponse GetExamples()
    {
        return new PostUpsertArtistResponse(HttpStatusCode.Created,
                                            "Artist created successfully.",
                                            new ArtistDto(ObjectId.GenerateNewId(),
                                                          "jon.doe",
                                                          "jon.doe@test.com",
                                                          4258,
                                                          "wallet-address",
                                                          "https://www.google.com",
                                                          "bio",
                                                          "3.jpg",
                                                          null,
                                                          "4.png",
                                                          null,
                                                          "https://www.instagram.com",
                                                          "https://www.twitter.com",
                                                          ObjectId.GenerateNewId().ToString()));
    }
}