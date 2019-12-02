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
            _userFactory = userFactory;
            _userRepository = userRepository;
        }

        public async Task<IUser> CreateUserCredentials(CustomerId customerId, ExternalUserId externalUserId)
        {
            var user = _userFactory.NewUser(customerId, externalUserId);
            await _userRepository.Add(user);
            return user;
        }
    }
}
