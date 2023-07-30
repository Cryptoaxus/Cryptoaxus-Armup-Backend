namespace CryptoAxus.Application.Features.NFT.PutNft.Handler;

public class PutNftHandler : BaseHandler<PutNftHandler>, IRequestHandler<PutNftRequest, PutNftResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public PutNftHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PutNftResponse> Handle(PutNftRequest request, CancellationToken cancellationToken)
    {
        NftDocument document = await _repository.FindByIdAsync(request.Id);

        if (document is null)
            return new NotFoundPutNftResponse($"No nft exist against id: {request.Id}");

        FilterDefinition<NftDocument> filterDefinition = Builders<NftDocument>.Filter.Eq(x => x.Id, request.Id);

        UpdateDefinition<NftDocument> updateDefinition = Builders<NftDocument>.Update
            .Set(x => x.ContractAddress, request.NftDto.ContractAddress ?? document.ContractAddress)
            .Set(x => x.Hash, request.NftDto.Hash ?? document.Hash)
            .Set(x => x.ImageStorageLink, request.NftDto.ImageStorageLink ?? document.ImageStorageLink)
            .Set(x => x.Signature, request.NftDto.Signature ?? document.Signature)
            .Set(x => x.TokenId, request.NftDto.TokenId ?? document.TokenId)
            .Set(x => x.Quantity, request.NftDto.Quantity ?? document.Quantity)
            .Set(x => x.Name, request.NftDto.Name ?? document.Name)
            .Set(x => x.Url, request.NftDto.Url ?? document.Url)
            .Set(x => x.Description, request.NftDto.Description ?? document.Description)
            .Set(x => x.Collection, request.NftDto.Collection ?? document.Collection)
            .Set(x => x.CollectionId, request.NftDto.CollectionId)
            .Set(x => x.BlockChain, request.NftDto.BlockChain ?? document.BlockChain)
            .Set(x => x.CreatorEarnings, request.NftDto.CreatorEarnings ?? document.CreatorEarnings)
            .Set(x => x.LastModifiedBy, request.NftDto.LastUpdatedBy)
            .Set(x => x.LastModifiedDate, DateTime.UtcNow);

        var updateResult = await _repository.UpdateOneAsync(filterDefinition, updateDefinition);

        NftDto dto = new NftDto();
        document.Adapt(dto);

        return updateResult.ModifiedCount <= 0
                ? new PutNftResponse(HttpStatusCode.BadRequest, "Unable to update the nft record.")
                : new PutNftResponse(HttpStatusCode.NoContent, "Nft updated successfully.", request.NftDto.Adapt(dto));
    }
}