using CryptoAxus.Application.Features.NFT.GetNftById.Request;

namespace CryptoAxus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NftController : BaseController<NftController>
{
    public NftController(IMediator mediator, ILogger<NftController> logger) : base(mediator, logger)
    {
    }

    [HttpGet("{id:regex(^[[A-Za-z0-9]]*$):required}", Name = "GetNftById", Order = 1)]
    public async Task<IActionResult> GetNftById([FromRoute] string id)
    {
        var response = await Mediator.Send(new GetNftByIdRequest(id));

        return response.StatusCode switch
        {
            HttpStatusCode.OK => Ok(response),
            HttpStatusCode.NotFound => NotFound(response),
            _ => BadRequest(response)
        };
    }

    [HttpPost(Name = "CreateNft", Order = 2)]
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