namespace CryptoAxus.Application.Features.Artist.PostArtist.Response;

public class PostArtistResponseExample : IExamplesProvider<PostArtistResponse>
{
    public PostArtistResponse GetExamples()
    {
        return new PostArtistResponse(HttpStatusCode.Created,
                                      "Artist created successfully",
                                      new ArtistDto("647115d2b38bc8ea242beb01".ToObjectId(),
                                                    "Ben Affleck",
                                                    "ben.affleck@gmail.com",
                                                    "0x647115d2b38bc8ea242beb01",
                                                    "https://www.google.com",
                                                    "Bio text goes here",
                                                    "3.gif",
                                                    "banner.jpg",
                                                    "https://www.instagram.com",
                                                    "https://www.twitter.com",
                                                    "647115d2b38bc8ea242beb01".ToObjectId()));
    }
}