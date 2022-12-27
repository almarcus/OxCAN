namespace OxCAN.Shared.Models;

public class Project
{
    public string? Link {get; set;}
    public string? Name {get; set;}
    public string? Timeframe {get; set;}

    public string? Display => $"{Name}, from {Timeframe}";
}