using StoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StoreApi.Services;

public class CartsService
{
    private readonly IMongoCollection<Cart> _cartsCollection;

    public CartsService(
        IOptions<StoreDatabaseSettings> storeDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            storeDatabaseSettings.Value.ConnectionString
            );

        var mongoDatabase = mongoClient.GetDatabase(
            storeDatabaseSettings.Value.DatabaseName
            );

        _cartsCollection = mongoDatabase.GetCollection<Cart>(
            storeDatabaseSettings.Value.CartsCollectionName
            );
    }

    public async Task<List<Cart>> GetCarts() =>
        await _cartsCollection.Find(_ => true).ToListAsync();

    public async Task<Cart?> GetCarts(string id) =>
        await _cartsCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Cart newCart) =>
        await _cartsCollection.InsertOneAsync(newCart);

    public async Task UpdateAsync(string id, Cart updateCart) =>
        await _cartsCollection.ReplaceOneAsync(x => x.Id == id, updateCart);

    public async Task RemoveAsync(string id) =>
        await _cartsCollection.DeleteOneAsync(x => x.Id == id);
}