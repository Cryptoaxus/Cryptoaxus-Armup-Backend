namespace CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Handler;

public class GetNftByCollectionIdHandler : BaseHandler<GetNftByCollectionIdHandler>,
                                           IRequestHandler<GetNftByCollectionIdRequest, GetNftByCollectionIdResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public GetNftByCollectionIdHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<GetNftByCollectionIdResponse> Handle(GetNftByCollectionIdRequest request,
                                                           CancellationToken cancellationToken)
    {
        List<NftDocument> result = await _repository.FilterBy(x => x.CollectionId == request.CollectionId,
                                                              pageNumber: null,
                                                              pageSize: null,
                                                              cancellationToken);

        if (result.Count.Equals(0))
            return new NotFoundGetNftByCollectionIdResponse($"No nft exist against collection id: {request.CollectionId}.");

        return new GetNftByCollectionIdResponse(HttpStatusCode.OK, "Records found successfully.", result.Adapt<IEnumerable<NftDto>>());
    }
}