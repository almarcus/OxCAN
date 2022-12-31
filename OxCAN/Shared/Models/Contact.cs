using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace OxCAN.Shared.Models;

[BsonIgnoreExtraElements]
public class Contact
{
    [Required(ErrorMessage = "First Name is required")]
    public string FirstName {get; set;}
        
    [Required(ErrorMessage = "Last Name is required")]
    public string LastName {get; set;}
    
    [Required(ErrorMessage = "Phone Number is required")]
    [Phone(ErrorMessage = "Phone number is not a valid phone number")]

    public string PhoneNumber {get; set;}

    [Required(ErrorMessage = "Email is required")]
    [EmailAddress(ErrorMessage = "Email is not a valid email address")]
    public string Email {get; set;}

    public string? Missing {get; set;}

    public bool NeighborhoodAdvocate {get; set;}
    public bool AttendMeetings {get; set;}
    public bool HelpIntroduceOxCAN {get; set;}
    public bool HelpBuildGreenways {get; set;}
    public bool HelpSendEmailsAndCalls {get; set;}
    public bool HelpCoordinateVolunteers {get; set;}
    public bool DonateGreenspace {get; set;}
    public bool DonateOther {get; set;}
    
}