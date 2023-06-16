namespace CryptoAxus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class HeartbeatController : ControllerBase
{
    [HttpGet]
    public IActionResult Check()
    {
        return Ok(new ResponseEntity(HttpStatusCode.OK, "API is up and running", true));
    }
}