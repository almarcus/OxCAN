using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

public class LoginModel
{
    [Required]
    public string UserID { get; set; }
}