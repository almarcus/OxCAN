using System.ComponentModel.DataAnnotations;

public class RegisterDTO
{
    [Required(ErrorMessage = "User ID is required.")]
    public string UserID {get; set;}

    [Required(ErrorMessage = "First Name is required.")]
    public string FirstName {get; set;}

    [Required(ErrorMessage = "Last Name is required.")]
    public string LastName {get; set;}
    
}