using lab1back.Logic;
using lab1back.Models;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[ApiController]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("users")]
    public IActionResult GetUsers()
    {
        try
        {
            return Ok(_userRepository.GetAllUsers());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpGet("user/{id}")]
    public IActionResult Get(Guid id)
    {
        try
        {
            var user = _userRepository.GetUserById(id);
            if (user is null)
                return NotFound();

            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("user/{id}")]
    public IActionResult Delete(Guid id)
    {
        try
        {
            _userRepository.DeleteUser(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost("user")]
    public IActionResult Add([FromBody]string name)
    {
        try
        {
            _userRepository.AddUser(new User{Name = name, Id = Guid.NewGuid()});
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}