namespace Weather.Infrastructure.Data.Connection;

using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using MongoDB.Driver;

public static class DataConnection
{
    public static IMongoDatabase GetOpenDatabase()
    {
        var connectionString = Environment.GetEnvironmentVariable("DBSERVER") ?? "mongodb://root:root@localhost:27017";
        var databaseName = Environment.GetEnvironmentVariable("DBDATABASE") ?? "weather";
        var mongoClient = new MongoClient(connectionString);
        return mongoClient.GetDatabase(databaseName);
    }
}