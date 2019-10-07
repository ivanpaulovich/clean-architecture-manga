namespace Manga.UnitTests.TestFixtures
{
    using Manga.Infrastructure.InMemoryDataAccess.Repositories;
    using Manga.Infrastructure.InMemoryDataAccess;

    public sealed class StandardFixture
    {
        public EntityFactory EntityFactory { get; }
        public MangaContext Context { get; }
        public AccountRepository AccountRepository { get; }
        public CustomerRepository CustomerRepository { get; }
        public UnitOfWork UnitOfWork { get; }

        public StandardFixture()
        {
            Context = new MangaContext();
            AccountRepository = new AccountRepository(Context);
            CustomerRepository = new CustomerRepository(Context);
            UnitOfWork = new UnitOfWork(Context);
            EntityFactory = new EntityFactory();
        }
    }
}
