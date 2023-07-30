namespace CryptoAxus.Application.Features.NFT.GetNftByCollectionId.Response;

public class NotFoundGetNftByCollectionIdResponseExample : IExamplesProvider<NotFoundGetNftByCollectionIdResponse>
{
    public NotFoundGetNftByCollectionIdResponse GetExamples()
    {
        return new NotFoundGetNftByCollectionIdResponse($"No nft exist against collection id: {ObjectId.GenerateNewId()}.");
    }
}