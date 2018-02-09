namespace Acerola.Infrastructure.DataAccess
{
    using Acerola.Domain;
    using Acerola.Domain.Accounts;
    using Acerola.Domain.Customers;
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

        public IMongoCollection<Account> Accounts
        {
            get
            {
                return database.GetCollection<Account>("Accounts");
            }
        }

        private void Map()
        {
            if (!BsonClassMap.IsClassMapRegistered(typeof(Entity)))
                BsonClassMap.RegisterClassMap<Entity>(cm =>
            {
                cm.AutoMap();
            });

            if (!BsonClassMap.IsClassMapRegistered(typeof(AggregateRoot)))
                BsonClassMap.RegisterClassMap<AggregateRoot>(cm =>
            {
                cm.AutoMap();
            });

            if (!BsonClassMap.IsClassMapRegistered(typeof(Account)))
                BsonClassMap.RegisterClassMap<Account>(cm =>
            {
                cm.AutoMap();
            });

            if (!BsonClassMap.IsClassMapRegistered(typeof(Transaction)))
                BsonClassMap.RegisterClassMap<Transaction>(cm =>
                {
                    cm.AutoMap();
                    cm.SetIsRootClass(true);
                    cm.AddKnownType(typeof(Debit));
                    cm.AddKnownType(typeof(Credit));
                });

            if (!BsonClassMap.IsClassMapRegistered(typeof(Credit)))
                BsonClassMap.RegisterClassMap<Credit>();
            if (!BsonClassMap.IsClassMapRegistered(typeof(Debit)))
                BsonClassMap.RegisterClassMap<Debit>();

            if (!BsonClassMap.IsClassMapRegistered(typeof(Customer)))
                BsonClassMap.RegisterClassMap<Customer>(cm =>
                {
                    cm.AutoMap();
                    cm.UnmapProperty(p => p.Accounts);
                });
        }
    }
}
