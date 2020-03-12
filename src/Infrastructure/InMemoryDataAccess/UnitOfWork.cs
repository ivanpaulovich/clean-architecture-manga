namespace Infrastructure.InMemoryDataAccess
{
    using System.Threading.Tasks;
    using Application.Services;

    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly MangaContext _context;

        public UnitOfWork(MangaContext context)
        {
            this._context = context;
        }

        public async Task<int> Save()
        {
            return await Task.FromResult(0)
                .ConfigureAwait(false);
        }
    }
}
