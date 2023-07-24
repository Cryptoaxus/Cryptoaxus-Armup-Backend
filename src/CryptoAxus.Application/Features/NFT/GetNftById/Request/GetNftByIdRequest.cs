namespace CryptoAxus.Application.Features.NFT.GetNftById.Request;

public class GetNftByIdRequest : IRequest<GetNftByIdResponse>
{
    internal string Id { get; set; }

    public GetNftByIdRequest(string id) => Id = id;
}