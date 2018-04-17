namespace MyProject.Infrastructure.MongoDataAccess
{
    using MyProject.Domain;
    using MyProject.Domain.Accounts;
    using MyProject.Domain.Customers;
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

            BsonClassMap.RegisterClassMap<AccountCollection>(cm =>
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

            BsonClassMap.RegisterClassMap<TransactionCollection>(cm =>
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
