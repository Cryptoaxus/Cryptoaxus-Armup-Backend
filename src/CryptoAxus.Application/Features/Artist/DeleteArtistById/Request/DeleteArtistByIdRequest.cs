namespace CryptoAxus.Application.Features.Artist.DeleteArtistById.Request;
public class DeleteArtistByIdRequest : IRequest<DeleteArtistByIdResponse>
{
    [JsonProperty("id", Required = Required.Always)]
    public string Id { get; set; }

    public DeleteArtistByIdRequest()
    {
    }

    public DeleteArtistByIdRequest(string id) => Id = id;
}