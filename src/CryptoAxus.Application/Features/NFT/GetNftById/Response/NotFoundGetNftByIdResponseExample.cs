namespace CryptoAxus.Application.Features.NFT.GetNftById.Response;

public class NotFoundGetNftByIdResponseExample : IExamplesProvider<NotFoundGetNftByIdResponse>
{
    public NotFoundGetNftByIdResponse GetExamples()
    {
        return new NotFoundGetNftByIdResponse($"No record found against id: {ObjectId.GenerateNewId()}.");
    }
}