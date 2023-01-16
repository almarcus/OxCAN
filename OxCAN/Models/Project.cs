using System.ComponentModel;
namespace OxCAN.Shared.Models;

public class Project
{
    public enum Status
    {
        Past,
        Future,
    }

    public string? Link {get; set;}
    public string? Name {get; set;}
    public string? Timeframe {get; set;}
    public Status ProjectStatus {get; set;}
    public string? ImageLink {get; set;} = "images/logo.png";
    public string? Description {get; set;}

    public string? MailToLink => $"mailto:everyone@oxfordcan.org?subject={Name}";
    public string? Display => $"{Name}, from {Timeframe}";

}