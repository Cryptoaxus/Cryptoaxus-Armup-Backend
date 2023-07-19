using Newtonsoft.Json.Linq;
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
        //var path = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToString()}/swagger/v1/swagger.json";
        var path = "http://localhost/swagger/v1/swagger.json";
        using HttpClient client = new HttpClient();
        var swaggerString = client.GetStringAsync(path, default).Result;
        JObject json = JObject.Parse(swaggerString);
        return Ok(json);

        //var swaggerDocument = _swaggerProvider.GetSwagger("v1");
        //return Ok(swaggerDocument);
    }
}