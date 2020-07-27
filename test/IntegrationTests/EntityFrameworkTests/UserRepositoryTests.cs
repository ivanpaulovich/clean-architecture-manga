namespace IntegrationTests.EntityFrameworkTests
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Common;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Infrastructure.DataAccess;
    using Infrastructure.DataAccess.Repositories;
    using Xunit;
    using User = Infrastructure.DataAccess.Entities.User;

    public sealed class UserRepositoryTests : IClassFixture<StandardFixture>
    {
        private readonly StandardFixture _fixture;

        public UserRepositoryTests(StandardFixture fixture) => this._fixture = fixture;

        [Fact]
        public async Task Add()
        {
            UserRepository userRepository = new UserRepository(this._fixture.Context);

            User user = new User(
                new UserId(Guid.NewGuid()),
                new ExternalUserId(Guid.NewGuid().ToString())
            );

            await userRepository
                .Add(user)
                .ConfigureAwait(false);

            await this._fixture.Context
                .SaveChangesAsync()
                .ConfigureAwait(false);

            bool hasAny = this._fixture.Context.Users
                .Any(e => e.UserId == user.UserId);

            Assert.True(hasAny);
        }

        [Fact]
        public async Task Find()
        {
            UserRepository userRepository = new UserRepository(this._fixture.Context);

            IUser? user = await userRepository
                .Find(SeedData.DefaultExternalUserId)
                .ConfigureAwait(false);

            Assert.IsType<User>(user);
        }
    }
}
