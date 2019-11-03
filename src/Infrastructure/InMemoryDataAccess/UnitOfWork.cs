namespace Infrastructure.InMemoryDataAccess
{
    using System.Threading.Tasks;
    using Application.Services;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private MangaContext context;

        public UnitOfWork(MangaContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult<int>(0);
        }
    }
}