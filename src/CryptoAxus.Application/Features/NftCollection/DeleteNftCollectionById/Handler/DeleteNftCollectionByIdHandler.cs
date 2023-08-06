namespace CryptoAxus.Application.Features.NftCollection.DeleteNftCollectionById.Handler;

public class DeleteNftCollectionByIdHandler : BaseHandler<DeleteNftCollectionByIdHandler>,
                                              IRequestHandler<DeleteNftCollectionByIdRequest, DeleteNftCollectionByIdResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;

    public DeleteNftCollectionByIdHandler(IRepository<NftCollectionsDocument> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteNftCollectionByIdResponse> Handle(DeleteNftCollectionByIdRequest request,
                                                              CancellationToken cancellationToken)
    {
        NftCollectionsDocument document = await _repository.FindByIdAsync(request.Id);

        if (document is null)
            return new NotFoundDeleteNftCollectionByIdResponse(request.Id.ToString());

        DeleteResult result = await _repository.DeleteByIdAsync(request.Id);

        return result.DeletedCount <= 0
                ? new BadRequestDeleteNftCollectionByIdResponse(request.Id.ToString())
                : new DeleteNftCollectionByIdResponse();
    }
}