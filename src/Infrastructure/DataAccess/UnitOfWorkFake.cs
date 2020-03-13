namespace Infrastructure.DataAccess
{
    using System.Threading.Tasks;
    using Application.Services;

    public sealed class UnitOfWorkFake : IUnitOfWork
    {
        public async Task<int> Save()
        {
            return await Task.FromResult(0)
                .ConfigureAwait(false);
        }
    }
}
