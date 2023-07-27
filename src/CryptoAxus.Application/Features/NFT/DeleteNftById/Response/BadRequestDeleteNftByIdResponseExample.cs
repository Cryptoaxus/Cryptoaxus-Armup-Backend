namespace CryptoAxus.Application.Features.NFT.DeleteNftById.Response;

public class BadRequestDeleteNftByIdResponseExample : IExamplesProvider<BadRequestDeleteNftByIdResponse>
{
    public BadRequestDeleteNftByIdResponse GetExamples()
    {
        return new BadRequestDeleteNftByIdResponse("Unable to delete nft with id: 507f191e810c19729de860ea");
    }
}