using CryptoAxus.Application.Contracts.Repositories;
using CryptoAxus.Application.Features.Artist.GetArtistById.Handler;
using CryptoAxus.Application.Features.DeleteArtistById.Request;
using CryptoAxus.Application.Features.DeleteArtistById.Response;
using CryptoAxus.Common.Helpers;
using MongoDB.Driver;

namespace CryptoAxus.Application.Features.DeleteArtistById.Handler;

public class DeleteArtistByIdHandler : BaseHandler<DeleteArtistByIdHandler>, IRequestHandler<DeleteArtistByIdRequest, DeleteArtistByIdResponse>
{ 
    private readonly IRepository<ArtistDocument> _repository;

    public DeleteArtistByIdHandler(IRepository<ArtistDocument> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteArtistByIdResponse> Handle(DeleteArtistByIdRequest request,CancellationToken cancellationToken = default)
    {
        ArgumentException.ThrowIfNullOrEmpty(request.Id, nameof(request.Id));
        
        ArtistDocument artist = await _repository.FindByIdAsync(request.Id.ToObjectId());

        if (artist is null)
        {
            return new DeleteArtistByIdResponse(HttpStatusCode.NotFound, message: $"No artist found against id: {request.Id}");
        }

        await _repository.DeleteByIdAsync(request.Id.ToObjectId());

        return new DeleteArtistByIdResponse(HttpStatusCode.NoContent, "Artist deleted successfully");
    }
}
