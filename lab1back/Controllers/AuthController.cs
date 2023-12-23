using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Entities;
using lab1back.Logic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace lab1back.Controllers;

[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUserRepository _userRepository;
    private readonly IConfiguration _configuration;
    
    public AuthController(IUserRepository userRepository, IConfiguration configuration)
    {
        _userRepository = userRepository;
        _configuration = configuration;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Add([FromBody]User user)
    {
        try
        {
            user.Id = Guid.NewGuid();
            user.Password = PassEncryptor.Encrypt(user.Password);
            await _userRepository.AddUser(user);
            return Ok(user.Id);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]User user)
    {
        try
        {
            var thisUser = (await _userRepository.GetAllUsers())
                .FirstOrDefault(i => i.Name == user.Name);
            if (thisUser is null)
                return BadRequest();
            if (!PassEncryptor.Verify(user.Password,thisUser.Password))
                return BadRequest();
            return Ok(CreateJwt());
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return BadRequest();
        }
    }

    private string CreateJwt()
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_configuration["JwtSettings:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(),
            Expires = DateTime.UtcNow.AddDays(1),
            Issuer = _configuration["JwtSettings:Issuer"],
            Audience = _configuration["JwtSettings:Audience"],
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}