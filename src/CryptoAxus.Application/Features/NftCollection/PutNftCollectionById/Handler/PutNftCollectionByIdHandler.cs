namespace CryptoAxus.Application.Features.NftCollection.PutNftCollectionById.Handler;

public class PutNftCollectionByIdHandler : BaseHandler<PutNftCollectionByIdHandler>,
                                           IRequestHandler<PutNftCollectionByIdRequest, PutNftCollectionByIdResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;

    public PutNftCollectionByIdHandler(IRepository<NftCollectionsDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PutNftCollectionByIdResponse> Handle(PutNftCollectionByIdRequest request,
                                                           CancellationToken cancellationToken)
    {
        NftCollectionsDocument document = await _repository.FindByIdAsync(request.Id);

        if (document is null)
            return new NotFoundPutNftCollectionByIdResponse(request.Id.ToString());

        FilterDefinition<NftCollectionsDocument> filterDefinition =
                Builders<NftCollectionsDocument>.Filter.Eq(x => x.Id, request.Id);

        UpdateDefinition<NftCollectionsDocument> updateDefinition = Builders<NftCollectionsDocument>.Update
               .Set(x => x.Url, request.Dto.Url)
               .Set(x => x.Category, request.Dto.Category)
               .Set(x => x.CollectionName, request.Dto.CollectionName)
    }
}