// <copyright file="UserRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Microsoft.EntityFrameworkCore;

    public sealed class UserRepository : IUserRepository
    {
        private readonly MangaContext _context;

        public UserRepository(MangaContext context) => this._context = context;

        public async Task Add(User user)
        {
            await this._context
                .Users
                .AddAsync((Entities.User)user)
                .ConfigureAwait(false);

            await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task<IUser> Find(ExternalUserId externalUserId)
        {
            User user = await this._context
                .Users
                .Where(a => a.ExternalUserId.Equals(externalUserId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            if (user == null)
            {
                return UserNull.Instance;
            }

            return user;
        }
    }
}
