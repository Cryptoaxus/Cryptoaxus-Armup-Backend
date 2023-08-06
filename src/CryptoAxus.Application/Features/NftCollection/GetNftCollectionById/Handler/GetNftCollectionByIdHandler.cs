namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionById.Handler;

public class GetNftCollectionByIdHandler : BaseHandler<GetNftCollectionByIdHandler>,
                                           IRequestHandler<GetNftCollectionByIdRequest, GetNftCollectionByIdResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;

    public GetNftCollectionByIdHandler(IRepository<NftCollectionsDocument> repository)
    {
        _repository = repository;
    }

    public async Task<GetNftCollectionByIdResponse> Handle(GetNftCollectionByIdRequest request,
                                                           CancellationToken cancellationToken)
    {
        NftCollectionsDocument result = await _repository.FindByIdAsync(request.Id);

        if (result is null)
            return new NotFoundGetNftCollectionByIdResponse($"No record exist against id: {request.Id}.");

        return new GetNftCollectionByIdResponse(result.Adapt<NftCollectionsDto>());
    }
}