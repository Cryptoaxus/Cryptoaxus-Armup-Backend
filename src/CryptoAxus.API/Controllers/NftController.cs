namespace CryptoAxus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NftController : BaseController<NftController>
{
    public NftController(IMediator mediator, ILogger<NftController> logger) : base(mediator, logger)
    {
    }

    [HttpPost(Name = "CreateNft", Order = 1)]
    public async Task<IActionResult> PostNft([FromBody] CreateNftDto nft,
                                             CancellationToken cancellationToken = default)
    {
        var response = await Mediator.Send(new PostNftRequest(nft), cancellationToken);

        return response.StatusCode switch
        {
            HttpStatusCode.Conflict => Conflict(response),
            HttpStatusCode.Created => CreatedAtRoute("GetOfferById", new { id = response.Result?.Id }, response),
            _ => BadRequest(response)
        };
    }
}