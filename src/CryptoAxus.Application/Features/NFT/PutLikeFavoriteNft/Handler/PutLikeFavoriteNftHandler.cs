namespace CryptoAxus.Application.Features.NFT.PutLikeFavoriteNft.Handler;

public class PutLikeFavoriteNftHandler : BaseHandler<PutLikeFavoriteNftHandler>,
                                           IRequestHandler<PutLikeFavoriteNftRequest, PutLikeFavoriteNftResponse>
{
    private readonly IRepository<NftDocument> _repository;

    public PutLikeFavoriteNftHandler(IRepository<NftDocument> repository)
    {
        _repository = repository;
    }

    public async Task<PutLikeFavoriteNftResponse> Handle(PutLikeFavoriteNftRequest request,
                                                         CancellationToken cancellationToken)
    {
        NftDocument document = await _repository.FindByIdAsync(request.NftId.ToObjectId());

        if (document is null)
            return new NotFoundPutLikeFavoriteNftResponse($"No nft exist against id: {request.NftId}.");

        FilterDefinition<NftDocument> filterDefinition = Builders<NftDocument>.Filter.Eq(x => x.Id, request.NftId.ToObjectId());

        UpdateDefinition<NftDocument> updateDefinition;

        if (request.Type.Equals(LikeFavoriteTypeEnum.Like))
        {
            if (document.Likes is not null && (bool)document.Likes?.Contains(request.UserId))
            {
                updateDefinition = Builders<NftDocument>.Update.Pull(x => x.Likes, request.UserId);
            }
            else
            {
                updateDefinition = Builders<NftDocument>.Update.Push(x => x.Likes, request.UserId);
            }
        }
        else
        {
            if (document.Favorites is not null && (bool)document.Favorites?.Contains(request.UserId))
            {
                updateDefinition = Builders<NftDocument>.Update.Pull(x => x.Favorites, request.UserId);
            }
            else
            {
                updateDefinition = Builders<NftDocument>.Update.Push(x => x.Favorites, request.UserId);
            }
        }

        UpdateResult updateResult = await _repository.UpdateOneAsync(filterDefinition, updateDefinition);

        return updateResult.ModifiedCount <= 0
                ? new BadRequestPutLikeFavoriteNftResponse("Unable to like/favorite nft.")
                : new PutLikeFavoriteNftResponse(HttpStatusCode.NoContent, "Nft updated successfully.");
    }
}