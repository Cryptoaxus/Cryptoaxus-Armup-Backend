namespace CryptoAxus.Application.Features.Artist.PatchArtist.Handler;

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
        ArtistDocument artist = await _repository.FindOneAsync(x => x.UserId.Equals(request.UserId), cancellationToken);

        if (artist == null)
            return new PatchArtistResponse(HttpStatusCode.NotFound, $"Unable to find artist with userId: {request.UserId}");

        UpdateArtistDto artistDto = new UpdateArtistDto();
        request.ArtistDto.ApplyTo(artistDto);

        FilterDefinition<ArtistDocument> filterDefinition = Builders<ArtistDocument>.Filter
                                                                                    .Eq(x => x.UserId, request.UserId);

        UpdateDefinition<ArtistDocument> updateDefinition = Builders<ArtistDocument>.Update
            .Set(x => x.Username, artistDto.Username ?? artist.Username)
            .Set(x => x.Email, artistDto.Email ?? artist.Email)
            .Set(x => x.UserId, artistDto.UserId ?? artist.UserId)
            .Set(x => x.ProfileImageAddress, artistDto.ProfileImageAddress ?? artist.ProfileImageAddress)
            .Set(x => x.Website, artistDto.Website ?? artist.Website)
            .Set(x => x.Bio, artistDto.Bio ?? artist.Bio)
            .Set(x => x.CoverImageAddress, artistDto.CoverImageAddress ?? artist.CoverImageAddress)
            .Set(x => x.Instagram, artistDto.Instagram ?? artist.Instagram)
            .Set(x => x.Twitter, artistDto.Twitter ?? artist.Twitter)
            .Set(x => x.LastModifiedBy, artistDto.LastModifiedBy ?? artist.LastModifiedBy)
            .Set(x => x.LastModifiedDate, DateTime.UtcNow);

        var updateResult = await _repository.UpdateOneAsync(filterDefinition, updateDefinition);

        return updateResult.ModifiedCount <= 0
                ? new PatchArtistResponse(HttpStatusCode.BadRequest, "Unable to update the artist record")
                : new PatchArtistResponse(HttpStatusCode.NoContent, "Artist record updated successfully");
    }
}