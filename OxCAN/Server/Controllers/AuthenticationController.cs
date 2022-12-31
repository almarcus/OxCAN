using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OxCAN.Shared.Services;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IConfiguration _configuration;
    private readonly ILogger _logger;
    private readonly IUserService _userService;

    public AuthenticationController(IConfiguration configuration,
                           ILogger<AuthenticationController> logger,
                           IUserService userService)
    {
        _configuration = configuration;
        _logger = logger;
        _userService = userService;
    }

    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginDTO login)
    {
        _logger.LogInformation($"Getting info for user: {login.UserID}");
        
        var user = _userService.Get(login.UserID);

        if (user == null) return BadRequest(new LoginResultDTO { Successful = false, Error = "Could not find user" });

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Name),
        };

        if(user.IsAdmin)
        {
            _logger.LogInformation("User is Admin");
            claims.Add(new Claim(ClaimTypes.Role, "Admin"));
        }

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

        return Ok(new LoginResultDTO { Successful = true, Token = new JwtSecurityTokenHandler().WriteToken(token) });
    }
}