namespace CryptoAxus.Application.Features.Artist.PatchArtistUserWalletAddress.Handler;
public class PatchArtistHandler : BaseHandler<PatchArtistHandler>, IRequestHandler<PatchArtistRequest, PatchArtistResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public PatchArtistHandler(IRepository<ArtistDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PatchArtistResponse> Handle(PatchArtistRequest request,
                                                          CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.UserWalletAddress, nameof(request.UserWalletAddress));

        ArtistDocument artist = await _repository.FindOneAsync(x => x.UserWalletAddress.Equals(request.UserWalletAddress));

        if (artist == null)
            return new PatchArtistResponse(HttpStatusCode.NotFound, $"Unable to find artist with wallet address: {request.UserWalletAddress}");

        ArtistDto artistDto = new ArtistDto();
        request.ArtistDto.Adapt(artistDto);
        FilterDefinition<ArtistDocument> filterDefinition =
                       Builders<ArtistDocument>.Filter.Eq(x => x.UserWalletAddress, request.UserWalletAddress);

        UpdateDefinition<ArtistDocument> updateDefinition = Builders<ArtistDocument>.Update
            .Set(x => x.Username, artistDto.Username)
            .Set(x => x.Email, artistDto.Email)
            .Set(x => x.UserWalletAddress, artistDto.UserWalletAddress)
            .Set(x => x.ProfileImageAddress, artistDto.ProfileImageAddress)
            .Set(x => x.Website, artistDto.Website)
            .Set(x => x.Bio, artistDto.Bio)
            .Set(x => x.CoverImageAddress, artistDto.CoverImageAddress)
            .Set(x => x.Instagram, artistDto.Instagram)
            .Set(x => x.Twitter, artistDto.Twitter);

        var updateResult = await _repository.UpdateOneAsync(filterDefinition, updateDefinition);

        return updateResult.ModifiedCount <= 0
                ? new PatchArtistResponse(HttpStatusCode.BadRequest, "Unable to update the username")
                : new PatchArtistResponse(HttpStatusCode.NoContent, "Artist username updated successfully");
    }
}