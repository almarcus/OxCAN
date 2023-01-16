using MongoDB.Bson.Serialization.Attributes;

namespace OxCAN.Shared.Models;

[BsonIgnoreExtraElements]
public class User
{
    public string UserID {get; set;}
    public string FirstName {get; set;}
    public string LastName {get; set;}
    public bool IsAdmin {get; set;} = false;

    public string Name => $"{FirstName} {LastName}";
}