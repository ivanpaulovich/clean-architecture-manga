// <copyright file="UserRepositoryFake.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Infrastructure.DataAccess.Repositories
{
    using System.Linq;
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;

    public sealed class UserRepositoryFake : IUserRepository
    {
        private readonly MangaContextFake _context;

        public UserRepositoryFake(MangaContextFake context) => this._context = context;

        public async Task<IUser> Find(ExternalUserId externalUserId)
        {
            User user = this._context
                .Users
                .SingleOrDefault(e => e.ExternalUserId.Equals(externalUserId));

            if (user is null)
            {
                return UserNull.Instance;
            }

            return await Task.FromResult(user)
                .ConfigureAwait(false);
        }

        public async Task Add(User user)
        {
            this._context
                .Users
                .Add((Entities.User)user);

            await Task.CompletedTask
                .ConfigureAwait(false);
        }
    }
}
