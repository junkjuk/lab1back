using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[ApiController]
[Route("[controller]")]
public class HealthcheckController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        try
        {
            return Ok(new HealthcheckResponse("Ok"));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new HealthcheckResponse("Error"));
        }
    }
}