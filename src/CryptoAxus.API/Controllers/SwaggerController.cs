using Swashbuckle.AspNetCore.Annotations;
using Swashbuckle.AspNetCore.Swagger;

namespace CryptoAxus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SwaggerController : ControllerBase
{
    private readonly ISwaggerProvider _swaggerProvider;

    public SwaggerController(ISwaggerProvider swaggerProvider)
    {
        _swaggerProvider = swaggerProvider;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get Swagger JSON", Tags = new[] { "Swagger" })]
    public IActionResult GetSwaggerJson()
    {
        var swaggerDocument = _swaggerProvider.GetSwagger("v1");
        return Ok(swaggerDocument);
    }
}