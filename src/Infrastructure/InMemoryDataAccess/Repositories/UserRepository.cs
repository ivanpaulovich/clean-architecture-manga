namespace Infrastructure.InMemoryDataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;

    public sealed class UserRepository : IUserRepository
    {
        private readonly MangaContext _context;

        public UserRepository(MangaContext context)
        {
            _context = context;
        }

        public async Task Add(IUser user)
        {
            _context.Users.Add((InMemoryDataAccess.User)user);
            await Task.CompletedTask;
        }

        public async Task<IUser> Get(ExternalUserId externalUserId)
        {
            User user = _context.Users
                .Where(e => e.ExternalUserId.Equals(externalUserId))
                .SingleOrDefault();

            if (user is null)
            {
                throw new UserNotFoundException($"The user {externalUserId} does not exist or is not processed yet.");
            }

            return await Task.FromResult<User>(user);
        }
    }
}
