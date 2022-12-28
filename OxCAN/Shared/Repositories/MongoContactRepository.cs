using OxCAN.Shared.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using MongoDB.Bson;

namespace OxCAN.Shared.Repositories;

public class MongoContactRepository : IContactRepository
{

    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoContactRepository(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("MongoDB");
        var mongoUrl = new MongoUrl(connectionString);
        var settings = MongoClientSettings.FromUrl(mongoUrl);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        _client = new MongoClient(settings);
        _database = _client.GetDatabase(mongoUrl.DatabaseName);
    }

    public Contact Save(Contact contact)
    {
        var collection = _database.GetCollection<Contact> ("Contact");

        collection.InsertOne(contact);

        return contact;
    }
}