namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Response;

public class DeleteNftByIdResponseExample : IExamplesProvider<DeleteNftByIdResponse>
{
    public DeleteNftByIdResponse GetExamples()
    {
        return new DeleteNftByIdResponse(HttpStatusCode.NoContent, "Nft deleted successfully.");
    }
}