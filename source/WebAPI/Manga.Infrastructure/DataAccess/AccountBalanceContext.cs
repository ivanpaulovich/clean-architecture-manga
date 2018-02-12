namespace Manga.Infrastructure.DataAccess
{
    using Manga.Domain;
    using Manga.Domain.Customers;
    using Manga.Domain.Customers.Accounts;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    public class AccountBalanceContext
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public AccountBalanceContext(string connectionString, string databaseName)
        {
            this.mongoClient = new MongoClient(connectionString);
            this.database = mongoClient.GetDatabase(databaseName);
            Map();
        }

        public IMongoCollection<Customer> Customers
        {
            get
            {
                return database.GetCollection<Customer>("Customers");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Account>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Transaction>(cm =>
            {
                cm.AutoMap();
                cm.SetIsRootClass(true);
                cm.AddKnownType(typeof(Debit));
                cm.AddKnownType(typeof(Credit));
            });

            BsonClassMap.RegisterClassMap<Customer>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
