using StoreApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace StoreApi.Services;

public class AddressesService
{
    private readonly IMongoCollection<Address> _addressesCollection;

    public AddressesService(
        IOptions<StoreDatabaseSettings> storeDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            storeDatabaseSettings.Value.ConnectionString
            );

        var mongoDatabase = mongoClient.GetDatabase(
            storeDatabaseSettings.Value.DatabaseName
            );

        _addressesCollection = mongoDatabase.GetCollection<Address>(
            storeDatabaseSettings.Value.AddressesCollectionName
            );
    }

    public async Task<List<Address>> GetAddresses() =>
        await _addressesCollection.Find(_ => true).ToListAsync();
    public async Task<List<Address>> GetAddressesByUserId(string id) =>
        await _addressesCollection.Find(x => x.UserId == id).ToListAsync();
    
    public async Task<Address?> GetAddresses(string id) =>
        await _addressesCollection.Find(x => x.Id == id).FirstOrDefaultAsync();
    public async Task CreateAsync(Address newAddress) =>
        await _addressesCollection.InsertOneAsync(newAddress);

    public async Task UpdateAsync(string id, Address updateAddress) =>
        await _addressesCollection.ReplaceOneAsync(x => x.Id == id, updateAddress);
    public async Task RemoveAsync(string id) =>
        await _addressesCollection.DeleteOneAsync(x => x.Id == id);
}