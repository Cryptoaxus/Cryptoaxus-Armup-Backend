namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Response;

public class NotFoundDeleteNftByIdResponseExample : IExamplesProvider<NotFoundDeleteNftByIdResponse>
{
    public NotFoundDeleteNftByIdResponse GetExamples()
    {
        return new NotFoundDeleteNftByIdResponse("No nft exist against id: 507f191e810c19729de860ea");
    }
}