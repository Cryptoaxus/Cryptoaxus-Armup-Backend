using Newtonsoft.Json.Linq;
using Swashbuckle.AspNetCore.Annotations;

namespace CryptoAxus.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class SwaggerController : ControllerBase
{
    public SwaggerController()
    {
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get Swagger JSON", Tags = new[] { "Swagger" })]
    public IActionResult GetSwaggerJson()
    {
        var path = "http://localhost/swagger/v1/swagger.json";
        using HttpClient client = new HttpClient();
        var swaggerString = client.GetStringAsync(path, default).Result;
        JObject json = JObject.Parse(swaggerString);
        return Ok(json);
    }
}