using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;

    public AuthenticationController(IConfiguration configuration,
                           ILogger<AuthenticationController> logger)
    {
        _configuration = configuration;
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginModel login)
    {

        //if (!result.Succeeded) return BadRequest(new LoginResult { Successful = false, Error = "Username and password are invalid." });

        var claims = new[]
        {
            new Claim(ClaimTypes.Name, login.Email)
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Authentication:JwtSecurityKey"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        var expiry = DateTime.Now.AddDays(Convert.ToInt32(_configuration["Authentication:JwtExpiryInDays"]));

        var token = new JwtSecurityToken(
            _configuration["Authentication:JwtIssuer"],
            _configuration["Authentication:JwtAudience"],
            claims,
            expires: expiry,
            signingCredentials: creds
        );

        return Ok(new LoginResult { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}