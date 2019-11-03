namespace Infrastructure.EntityFrameworkDataAccess
{
    using System.Threading.Tasks;
    using System;
    using Application.Services;

    public sealed class UnitOfWork : IUnitOfWork, IDisposable
    {
        private MangaContext context;

        public UnitOfWork(MangaContext context)
        {
            this.context = context;
        }

        public async Task<int> Save()
        {
            int affectedRows = await context.SaveChangesAsync();
            return affectedRows;
        }

        private bool disposed = false;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}