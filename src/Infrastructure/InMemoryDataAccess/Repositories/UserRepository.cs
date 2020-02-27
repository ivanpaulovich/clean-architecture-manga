namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using User = InMemoryDataAccess.User;

    public sealed class UserRepository : IUserRepository
    {
        private readonly MangaContext _context;

        public UserRepository(MangaContext context)
        {
            this._context = context;
        }

        public async Task Add(IUser user)
        {
            this._context.Users.Add((User)user);
            await Task.CompletedTask
                .ConfigureAwait(false);
        }

        public async Task<IUser> GetUser(ExternalUserId externalUserId)
        {
            Domain.Security.User user = this._context.Users
                .Where(e => e.ExternalUserId.Equals(externalUserId))
                .SingleOrDefault();

            if (user is null)
            {
                throw new UserNotFoundException($"The user {externalUserId} does not exist or is not processed yet.");
            }

            return await Task.FromResult(user)
                .ConfigureAwait(false);
        }
    }
}
