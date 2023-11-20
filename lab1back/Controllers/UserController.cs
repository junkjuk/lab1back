using lab1back.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[ApiController]
public class UserController : ControllerBase
{
    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        try
        {
            return Ok(new HealthcheckResponse(""));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new HealthcheckResponse("Error"));
        }
    }
    
    [HttpGet("user/{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            return Ok(new HealthcheckResponse(id.ToString()));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new HealthcheckResponse("Error"));
        }
    }

    [HttpDelete("user/{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            return Ok(new HealthcheckResponse(id.ToString()));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new HealthcheckResponse("Error"));
        }
    }

    [HttpPost("user")]
    public IActionResult Delete([FromBody]string name)
    {
        try
        {
            return Ok(new HealthcheckResponse(name));
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest(new HealthcheckResponse("Error"));
        }
    }
}