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

        bool artistExists = await _repository.Exists(x => x.UserId.Equals(request.Artist.UserWalletAddress),
                                                     cancellationToken);

        if (artistExists)
            return new PostArtistResponse(HttpStatusCode.Conflict, "Artist with same wallet address already exists",
                                          request.Artist.Adapt<ArtistDto>());

        ArtistDocument artistDocument = request.Artist.Adapt<ArtistDocument>();

        await _repository.InsertOneAsync(artistDocument);

        return new PostArtistResponse(HttpStatusCode.Created, "Artist created successfully", artistDocument.Adapt<ArtistDto>());
    }
}