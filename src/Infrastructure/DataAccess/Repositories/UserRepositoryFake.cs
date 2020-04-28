namespace Infrastructure.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using User = Entities.User;

    public sealed class UserRepositoryFake : IUserRepository
    {
        private readonly MangaContextFake _context;

        public UserRepositoryFake(MangaContextFake context)
        {
            this._context = context;
        }

        public async Task Add(IUser user)
        {
            this._context
                .Users
                .Add((User)user);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<IUser> GetUser(ExternalUserId externalUserId)
        {
            Domain.Security.User user = this._context
                .Users
                .SingleOrDefault(e => e.ExternalUserId.Equals(externalUserId));

            if (user is null)
            {
                return null;
            }

            return await Task.FromResult(user)
                .ConfigureAwait(false);
        }
    }
}
