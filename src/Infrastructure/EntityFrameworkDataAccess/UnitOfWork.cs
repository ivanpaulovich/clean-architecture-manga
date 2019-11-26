namespace Infrastructure.EntityFrameworkDataAccess
{
    using System;
    using System.Threading.Tasks;
    using Application.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly MangaContext _context;
        private bool _disposed = false;

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
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            _disposed = true;
        }
    }
}