namespace Manga.Infrastructure.MongoDataAccess
{
    using Manga.Infrastructure.MongoDataAccess.Entities;
    using MongoDB.Bson.Serialization;
    using MongoDB.Driver;

    public class Context
    {
        private readonly MongoClient mongoClient;
        private readonly IMongoDatabase database;

        public Context(string connectionString, string databaseName)
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

        public IMongoCollection<Account> Accounts
        {
            get
            {
                return database.GetCollection<Account>("Accounts");
            }
        }

        public IMongoCollection<Credit> Credits
        {
            get
            {
                return database.GetCollection<Credit>("Credits");
            }
        }

        public IMongoCollection<Debit> Debits
        {
            get
            {
                return database.GetCollection<Debit>("Debits");
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
