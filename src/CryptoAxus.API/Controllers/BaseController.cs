namespace CryptoAxus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BaseController<TController> : ControllerBase where TController : BaseController<TController>
{
    protected readonly IMediator Mediator;
    protected readonly ILogger<TController> Logger;

    public BaseController(IMediator mediator, ILogger<TController> logger)
    {
        Mediator = mediator;
        Logger = logger;
    }
}