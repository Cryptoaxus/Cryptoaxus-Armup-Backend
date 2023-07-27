namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Handler;

public class DeleteNftByIdHandler : BaseHandler<DeleteNftByIdHandler>, IRequestHandler<DeleteNftByIdRequest, DeleteNftByIdResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public DeleteNftByIdHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<DeleteNftByIdResponse> Handle(DeleteNftByIdRequest request, CancellationToken cancellationToken)
    {
        NftDocument nft = await _repository.FindByIdAsync(request.Id);

        if (nft is null)
            return new NotFoundDeleteNftByIdResponse($"No nft exist against id: {request.Id}.");

        var result = await _repository.DeleteByIdAsync(request.Id);

        if (result.DeletedCount.Equals(0))
            return new BadRequestDeleteNftByIdResponse($"Unable to delete nft with id: {request.Id}.");

        return new DeleteNftByIdResponse(HttpStatusCode.NoContent, "Nft deleted successfully.");
    }
}