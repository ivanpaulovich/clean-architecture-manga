namespace Infrastructure.EntityFrameworkDataAccess
{
    using System.Threading.Tasks;
    using System;
    using Application.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MangaContext _context;

        public UnitOfWork(MangaContext context)
        {
            _context = context;
        }

        public async Task<int> Save()
        {
            int affectedRows = await _context.SaveChangesAsync();
            return affectedRows;
        }

        public void Dispose()
            => _context?.Dispose();
    }
}
