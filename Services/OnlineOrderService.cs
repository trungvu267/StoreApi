using StoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StoreApi.Services;

public class OnlineOrdersService
{
    private readonly IMongoCollection<OnlineOrder> _onlineOrdersCollection;

    public OnlineOrdersService(
        IOptions<StoreDatabaseSettings> storeDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            storeDatabaseSettings.Value.ConnectionString
            );

        var mongoDatabase = mongoClient.GetDatabase(
            storeDatabaseSettings.Value.DatabaseName
            );

        _onlineOrdersCollection = mongoDatabase.GetCollection<OnlineOrder>(
            storeDatabaseSettings.Value.OnlineOrdersCollectionName
            );
    }

    public async Task<List<OnlineOrder>> GetOnlineOrders() =>
        await _onlineOrdersCollection.Find(_ => true).ToListAsync();
    public async Task<List<OnlineOrder>> GetOnlineOrdersByUserId(string id) =>
        await _onlineOrdersCollection.Find(x => x.UserId == id).ToListAsync();

    public async Task<OnlineOrder?> GetOnlineOrders(string id) =>
        await _onlineOrdersCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(OnlineOrder newOnlineOrder) =>
        await _onlineOrdersCollection.InsertOneAsync(newOnlineOrder);

    public async Task UpdateAsync(string id, OnlineOrder updateOnlineOrder) =>
        await _onlineOrdersCollection.ReplaceOneAsync(x => x.Id == id, updateOnlineOrder);

    public async Task RemoveAsync(string id) =>
        await _onlineOrdersCollection.DeleteOneAsync(x => x.Id == id);
}