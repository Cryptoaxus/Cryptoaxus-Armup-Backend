namespace CryptoAxus.Application.Features.NFT.GetNftById.Handler;

public class GetNftByIdHandler : BaseHandler<GetNftByIdHandler>, IRequestHandler<GetNftByIdRequest, GetNftByIdResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public GetNftByIdHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<GetNftByIdResponse> Handle(GetNftByIdRequest request,
                                                 CancellationToken cancellationToken = default)
    {
        NftDocument? result = await _repository.FindByIdAsync(request.Id.ToObjectId());

        if (result is null)
            return new GetNftByIdResponse(HttpStatusCode.NotFound, $"No record found against id: {request.Id}.");

        return new GetNftByIdResponse(HttpStatusCode.OK, "Nft found successfully.", result.Adapt<NftDto>());
    }
}