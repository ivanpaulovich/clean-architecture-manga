namespace Domain.Security
{
    using System.Threading.Tasks;
    using Domain.Customers.ValueObjects;
    using Domain.Security.ValueObjects;

    public class SecurityService
    {
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;

        public SecurityService(
            IUserFactory userFactory,
            IUserRepository userRepository)
        {
            this._userFactory = userFactory;
            this._userRepository = userRepository;
        }

        public async Task<IUser> CreateUserCredentials(CustomerId customerId, ExternalUserId externalUserId)
        {
            var user = this._userFactory.NewUser(customerId, externalUserId);
            await this._userRepository.Add(user);
            return user;
        }
    }
}
