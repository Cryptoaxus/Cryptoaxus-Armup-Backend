namespace CryptoAxus.Application.Features.NftCollection.GetNftCollectionsByWalletAddress.Handler;

public class GetNftCollectionsByWalletAddressHandler : BaseHandler<GetNftCollectionsByWalletAddressHandler>,
                                                       IRequestHandler<GetNftCollectionsByWalletAddressRequest, GetNftCollectionsByWalletAddressResponse>
{
    private readonly IRepository<NftCollectionsDocument> _repository;

    public GetNftCollectionsByWalletAddressHandler(IRepository<NftCollectionsDocument> repository)
    {
        _repository = repository;
    }

    public async Task<GetNftCollectionsByWalletAddressResponse> Handle(GetNftCollectionsByWalletAddressRequest request,
                                                                       CancellationToken cancellationToken)
    {
        List<NftCollectionsDocument> documents = await _repository.FilterByAsync(x => x.ArtistWalletAddress.Equals(request.WalletAddress),
                                                                                 cancellationToken: cancellationToken);

        if (documents.Count.Equals(0))
            return new NotFoundGetNftCollectionsByWalletAddressResponse(request.WalletAddress);

        return new GetNftCollectionsByWalletAddressResponse(documents.Adapt<List<NftCollectionsDto>>());
    }
}