using CryptoAxus.Application.Features.NftCollection.PostNftCollection.Request;

namespace CryptoAxus.Application.Features.NftCollection.PostNftCollection.Handler;

public class PostNftCollectionHandler : BaseHandler<PostNftCollectionHandler>,
                                        IRequestHandler<PostNftCollectionRequest, PostNftCollectionResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;

    public PostNftCollectionHandler(IRepository<NftCollectionsDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PostNftCollectionResponse> Handle(PostNftCollectionRequest request,
                                                        CancellationToken cancellationToken)
    {
        var exists = await _repository.Exists(x => x.CollectionName.Equals(request.NftCollection.CollectionName), cancellationToken);

        if (exists)
            return new ConflictPostNftCollectionResponse("Collection with same name already exits.");

        NftCollectionsDocument document = request.NftCollection.Adapt<NftCollectionsDocument>();

        await _repository.InsertOneAsync(document);

        return new PostNftCollectionResponse(document.Adapt<NftCollectionsDto>());
    }
}