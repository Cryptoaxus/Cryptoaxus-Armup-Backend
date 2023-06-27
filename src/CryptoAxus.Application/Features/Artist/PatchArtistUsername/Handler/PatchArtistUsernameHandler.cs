namespace CryptoAxus.Application.Features.Artist.PatchArtistUsername.Handler;

public class PatchArtistUsernameHandler : BaseHandler<PatchArtistUsernameHandler>, IRequestHandler<PatchArtistUsernameRequest, PatchArtistUsernameResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public PatchArtistUsernameHandler(IRepository<ArtistDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PatchArtistUsernameResponse> Handle(PatchArtistUsernameRequest request,
                                                          CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.UserWalletAddress, nameof(request.UserWalletAddress));

        ArtistDocument artist = await _repository.FindOneAsync(x => x.UserWalletAddress.Equals(request.UserWalletAddress));

        if (artist == null)
            return new PatchArtistUsernameResponse(HttpStatusCode.NotFound, $"Unable to find artist with wallet address: {request.UserWalletAddress}");

        ArtistDto artistDto = new ArtistDto();
        request.ArtistDto.ApplyTo(artistDto);

        FilterDefinition<ArtistDocument> filterDefinition =
                Builders<ArtistDocument>.Filter.Eq(x => x.UserWalletAddress, request.UserWalletAddress);

        UpdateDefinition<ArtistDocument> updateDefinition = Builders<ArtistDocument>.Update
            .Set(x => x.Username, artistDto.Username);

        var updateResult = await _repository.UpdateOneAsync(filterDefinition, updateDefinition);        

        return updateResult.ModifiedCount <= 0
                ? new PatchArtistUsernameResponse(HttpStatusCode.BadRequest, "Unable to update the username")
                : new PatchArtistUsernameResponse(HttpStatusCode.NoContent, "Artist username updated successfully");
    }
}