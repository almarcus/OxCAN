using OxCAN.Shared.Models;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace OxCAN.Shared.Repositories;

public class MongoUserRepository : IUserRepository
{

    private readonly MongoClient _client;
    private readonly IMongoDatabase _database;

    public MongoUserRepository(IConfiguration config)
    {
        var connectionString = config.GetConnectionString("MongoDB");
        var mongoUrl = new MongoUrl(connectionString);
        var settings = MongoClientSettings.FromUrl(mongoUrl);
        settings.ServerApi = new ServerApi(ServerApiVersion.V1);
        _client = new MongoClient(settings);
        _database = _client.GetDatabase(mongoUrl.DatabaseName);
    }


    public User? Get(string userid)
    {
        var collection = _database.GetCollection<User>("User");
        return collection.AsQueryable<User>().FirstOrDefault(x => x.UserID == userid);
    }
}