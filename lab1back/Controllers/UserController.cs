using Entities;
using lab1back.Logic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace lab1back.Controllers;

[Authorize, ApiController]
public class UserController : ControllerBase
{

    private readonly IUserRepository _userRepository;
    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet("users")]
    public async Task<IActionResult> GetUsers()
    {
        try
        {
            var users = await _userRepository.GetAllUsers();
            return Ok(users);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpGet("user/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        try
        {
            var user = await _userRepository.GetUserById(id);
            if (user is null)
                return NotFound();

            return Ok(user);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpDelete("user/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            await _userRepository.DeleteUser(id);
            return Ok();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    [HttpPost("user")]
    public async Task<IActionResult> Add([FromBody]string name)
    {
        try
        {
            var user = new User {Name = name, Id = Guid.NewGuid()};
            await _userRepository.AddUser(user);
            return Ok(user.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
}