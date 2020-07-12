// <copyright file="SignUpUseCase.cs" company="Ivan Paulovich">
// Copyright © Ivan Paulovich. All rights reserved.
// </copyright>

namespace Application.UseCases.SignUp
{
    using System.Threading.Tasks;
    using Domain.Security;
    using Domain.Security.ValueObjects;
    using Services;

    /// <inheritdoc />
    public sealed class SignUpUseCase : ISignUpUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IUserFactory _userFactory;
        private readonly IUserRepository _userRepository;
        private readonly IUserService _userService;
        private IOutputPort? _outputPort;

        /// <summary>
        ///     Initializes a new instance of the <see cref="SignUpUseCase" /> class.
        /// </summary>
        /// <param name="unitOfWork">Unit of Work.</param>
        /// <param name="userService">User Service.</param>
        /// <param name="userRepository">User Repository.</param>
        /// <param name="userFactory"></param>
        public SignUpUseCase(
            IUnitOfWork unitOfWork,
            IUserService userService,
            IUserRepository userRepository,
            IUserFactory userFactory)
        {
            this._unitOfWork = unitOfWork;
            this._userService = userService;
            this._userRepository = userRepository;
            this._userFactory = userFactory;
        }

        /// <inheritdoc />
        public void SetOutputPort(IOutputPort outputPort) => this._outputPort = outputPort;

        /// <inheritdoc />
        public Task Execute()
        {
            ExternalUserId externalUserId = this._userService
                .GetCurrentUser();

            return this.SignUpInternal(externalUserId);
        }

        private async Task SignUpInternal(ExternalUserId externalUserId)
        {
            IUser findUser = await this._userRepository
                .Find(externalUserId)
                .ConfigureAwait(false);

            if (findUser is User existingUser)
            {
                this._outputPort?.UserAlreadyExists(existingUser);
            }
            else
            {
                User user = this._userFactory
                    .NewUser(externalUserId);

                await this.CreateUser(user)
                    .ConfigureAwait(false);

                this._outputPort?.Ok(user);
            }
        }

        private async Task CreateUser(User user)
        {
            await this._userRepository
                .Add(user)
                .ConfigureAwait(false);

            await this._unitOfWork
                .Save()
                .ConfigureAwait(false);
        }
    }
}
