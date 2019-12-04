namespace Infrastructure.EntityFrameworkDataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    public sealed class UserRepository : IUserRepository
    {
        private readonly MangaContext _context;

        public UserRepository(MangaContext context)
        {
            _context = context ??
                throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(IUser user)
        {
            await _context.Users.AddAsync((EntityFrameworkDataAccess.User)user);
            await _context.SaveChangesAsync();
        }

        public async Task<IUser> Get(ExternalUserId externalUserId)
        {
            var user = await _context
                .Users
                .Where(a => a.ExternalUserId.Equals(externalUserId))
                .SingleOrDefaultAsync();

            if (user is null)
            {
                throw new UserNotFoundException($"The user {externalUserId} does not exist or is not processed yet.");
            }

            return user;
        }
    }
}
