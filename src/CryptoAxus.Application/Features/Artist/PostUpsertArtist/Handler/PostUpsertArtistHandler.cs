namespace CryptoAxus.Application.Features.Artist.PostUpsertArtist.Handler;

public class PostUpsertArtistHandler : BaseHandler<PostUpsertArtistHandler>,
                                       IRequestHandler<PostUpsertArtistRequest, PostUpsertArtistResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public PostUpsertArtistHandler(IRepository<ArtistDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PostUpsertArtistResponse> Handle(PostUpsertArtistRequest request,
                                                       CancellationToken cancellationToken)
    {
        // Creates new artist
        if (!string.IsNullOrEmpty(request.Artist.WalletAddress))
        {
            var result = await _repository.FindOneAsync(x => x.UserId.Equals(request.Artist.UserId) ||
                                                                                   x.WalletAddress != null &&
                                                                                   x.WalletAddress.Equals(request.Artist.WalletAddress), cancellationToken);

            if (result != null)
            {
                return new ConflictPostUpsertArtistResponse();
            }

            ArtistDocument artistDocument = request.Artist.Adapt<ArtistDocument>();

            await _repository.InsertOneAsync(artistDocument);

            return new PostUpsertArtistResponse(HttpStatusCode.Created, "Artist created successfully", artistDocument.Adapt<ArtistDto>());
        }
        else
        {
            FilterDefinition<ArtistDocument> filterDefinition = Builders<ArtistDocument>.Filter.Eq(x => x.WalletAddress, request.Artist.WalletAddress);

            UpdateDefinition<ArtistDocument> updateDefinition = Builders<ArtistDocument>.Update
                   .Set(x => x.UserId, request.Artist.UserId)
                   .Set(x => x.Bio, request.Artist.Bio)
                   .Set(x => x.CoverImageAddress, request.Artist.CoverImageAddress)
                   .Set(x => x.Email, request.Artist.Email)
                   .Set(x => x.Instagram, request.Artist.Instagram)
                   .Set(x => x.ProfileImageAddress, request.Artist.ProfileImageAddress)
                   .Set(x => x.Twitter, request.Artist.Twitter)
                   .Set(x => x.Username, request.Artist.Username)
                   .Set(x => x.Website, request.Artist.Website)
                   .Set(x => x.LastModifiedDate, DateTime.UtcNow);

            var updateTask = _repository.UpdateOneAsync(filterDefinition, updateDefinition);

            var documentTask = _repository.FindOneAsync(x => x.WalletAddress != null &&
                                                                                        x.WalletAddress.Equals(request.Artist.WalletAddress),
                                                        cancellationToken);

            await Task.WhenAll(updateTask, documentTask);

            if (updateTask.Result.ModifiedCount.Equals(0))
                return new BadRequestPostUpsertArtistResponse($"Unable to update artist with wallet address: {request.Artist.WalletAddress}.");
            return new PostUpsertArtistResponse(HttpStatusCode.NoContent,
                                                "Artist updated successfully.",
                                                documentTask.Result.Adapt<ArtistDto>());
        }
    }
}