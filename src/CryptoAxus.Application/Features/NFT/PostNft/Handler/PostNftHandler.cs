namespace CryptoAxus.Application.Features.NFT.PostNft.Handler;

public class PostNftHandler : BaseHandler<PostNftHandler>, IRequestHandler<PostNftRequest, PostNftResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public PostNftHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PostNftResponse> Handle(PostNftRequest request, CancellationToken cancellationToken = default)
    {
        bool exists = await _repository.Exists(x => x.Name.Equals(request.Nft.Name), cancellationToken);

        if (exists)
            return new PostNftResponse(HttpStatusCode.Conflict, $"Nft with same name already exists: {request.Nft.Name}.");

        NftDocument nft = request.Nft.Adapt<NftDocument>();

        await _repository.InsertOneAsync(nft);

        return new PostNftResponse(nft.Adapt<NftDto>());
    }
}