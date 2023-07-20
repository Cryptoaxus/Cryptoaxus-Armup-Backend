namespace CryptoAxus.Application.Features.Artist.PostArtist.Request;

public class PostArtistRequestExample : IExamplesProvider<PostArtistRequest>
{
    public PostArtistRequest GetExamples()
    {
        return new PostArtistRequest(new CreateArtistDto("tom.cruise",
                                                         "tom.cruise@armup.com",
                                                         5133,
                                                         "https://www.tomcruise.com",
                                                         "Versatile actor",
                                                         "tom-cruise.png",
                                                         "tom-cruise-cover.png",
                                                         "https://www.instagram.com/tomcruise",
                                                         "https://www.twitter.com/tomcruise",
                                                         ObjectId.GenerateNewId()));
    }
}