namespace CryptoAxus.Application.Features.Artist.PostArtist.Request;

public class PostArtistRequestExample : IExamplesProvider<PostArtistRequest>
{
    public PostArtistRequest GetExamples()
    {
        return new PostArtistRequest(new CreateArtistDto("tom.cruise",
                                                         "tom.cruise@armup.com",
                                                         "0x51c330436F289192F43666e51Df72Ec06F66Dad9",
                                                         "https://www.tomcruise.com",
                                                         "Versatile actor",
                                                         "tom-cruise.png",
                                                         "tom-cruise-cover.png",
                                                         "https://www.instagram.com/tomcruise",
                                                         "https://www.twitter.com/tomcruise",
                                                         507191));
    }
}