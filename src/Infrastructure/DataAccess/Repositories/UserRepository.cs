// <copyright file="UserRepository.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Microsoft.EntityFrameworkCore;
    using User = Entities.User;

    public sealed class UserRepository : IUserRepository
    {
        private readonly MangaContext _context;

        public UserRepository(MangaContext context) => this._context = context ??
                                                                       throw new ArgumentNullException(nameof(context));

        public async Task Add(IUser user)
        {
            await this._context
                .Users
                .AddAsync((User)user)
                .ConfigureAwait(false);
            await this._context
                .SaveChangesAsync()
                .ConfigureAwait(false);
        }

        public async Task<IUser> GetUser(ExternalUserId externalUserId)
        {
            User user = await this._context
                .Users
                .Where(a => a.ExternalUserId.Equals(externalUserId))
                .SingleOrDefaultAsync()
                .ConfigureAwait(false);

            return user;
        }
    }
}
