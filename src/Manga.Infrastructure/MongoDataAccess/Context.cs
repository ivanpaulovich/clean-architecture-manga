namespace Manga.Infrastructure.MongoDataAccess
{
    using Manga.Infrastructure.MongoDataAccess.Entities;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    public class Context
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _database;

        public Context(string connectionString, string databaseName)
        {
            _mongoClient = new MongoClient(connectionString);
            _database = _mongoClient.GetDatabase(databaseName);
            Map();
        }

        internal IMongoCollection<Customer> Customers
        {
            get
            {
                return _database.GetCollection<Customer>("Customers");
            }
        }

        internal IMongoCollection<Account> Accounts
        {
            get
            {
                return _database.GetCollection<Account>("Accounts");
            }
        }

        internal IMongoCollection<Credit> Credits
        {
            get
            {
                return _database.GetCollection<Credit>("Credits");
            }
        }

        internal IMongoCollection<Debit> Debits
        {
            get
            {
                return _database.GetCollection<Debit>("Debits");
            }
        }

        private void Map()
        {
            BsonClassMap.RegisterClassMap<Account>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Credit>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Debit>(cm =>
            {
                cm.AutoMap();
            });

            BsonClassMap.RegisterClassMap<Customer>(cm =>
            {
                cm.AutoMap();
            });
        }
    }
}
