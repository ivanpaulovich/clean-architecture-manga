namespace UnitTests.TestFixtures
{
    using Infrastructure.InMemoryDataAccess;
    using Infrastructure.InMemoryDataAccess.Repositories;
    using Infrastructure.InMemoryDataAccess.Services;

    public sealed class StandardFixture
    {
        public StandardFixture()
        {
            Context = new MangaContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
            UserService = new UserService();
        }

        public EntityFactory EntityFactory { get; }

        public MangaContext Context { get; }

        public AccountRepository AccountRepository { get; }

        public CustomerRepository CustomerRepository { get; }

        public UnitOfWork UnitOfWork { get; }

        public UserService UserService { get; }
    }
}
