public class StoreDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string ProductsCollectionName { get; set; } = null!;
    public string UsersCollectionName { get; set; } = null!;
    public string CartsCollectionName { get; set; } = null!;
    public string AddressesCollectionName { get; set; } = null!;
    public string OnlineOrdersCollectionName { get; set; } = null!;
}