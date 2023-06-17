namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Handler;

public class DeleteArtistByIdHandler : BaseHandler<DeleteArtistByIdHandler>, IRequestHandler<DeleteArtistByIdRequest, DeleteArtistByIdResponse>
{
    private readonly IRepository<ArtistDocument> _repository;

    public DeleteArtistByIdHandler(IRepository<ArtistDocument> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteArtistByIdResponse> Handle(DeleteArtistByIdRequest request, CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Id, nameof(request.Id));

        ArtistDocument? artist = await _repository.FindByIdAsync(request.Id.ToObjectId());

        if (artist is null)
            return new DeleteArtistByIdResponse(HttpStatusCode.NotFound, message: $"No artist found against id: {request.Id}");

        DeleteResult result = await _repository.DeleteByIdAsync(request.Id.ToObjectId());

        if (result.DeletedCount == 0)
            return new DeleteArtistByIdResponse(HttpStatusCode.BadRequest, $"Unable to delete artist against id: {request.Id}");

        return new DeleteArtistByIdResponse(HttpStatusCode.NoContent, "Artist deleted successfully");
    }
}