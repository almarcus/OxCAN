using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

public class LoginDTO
{
    [Required]
    public string UserID { get; set; }
}