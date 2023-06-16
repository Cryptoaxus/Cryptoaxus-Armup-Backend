namespace CryptoAxus.Application.Features.Artist.PostArtist.Handler;

public class PostArtistHandler : BaseHandler<PostArtistHandler>, IRequestHandler<PostArtistRequest, PostArtistResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public PostArtistHandler(IRepository<ArtistDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PostArtistResponse> Handle(PostArtistRequest request,
                                                 CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Artist.ToString(), nameof(request.Artist));

        bool artistExists = await _repository.Exists(x => x.UserWalletAddress.Equals(request.Artist.UserWalletAddress),
                                                     cancellationToken);

        if (artistExists)
            return new PostArtistResponse(HttpStatusCode.BadRequest, "Artist with same wallet address already exists", request.Artist);

        await _repository.InsertOneAsync(request.Artist.Adapt<ArtistDocument>());

        return new PostArtistResponse(HttpStatusCode.Created, "Artist created successfully", request.Artist);
    }
}