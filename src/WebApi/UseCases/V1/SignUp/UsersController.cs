namespace WebApi.UseCases.V1.SignUp
{
    using System.Threading.Tasks;
    using Application.UseCases.SignUp;
    using Domain.Security;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Modules.Common;
    using ViewModels;

    /// <summary>
    ///     Customers
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class UsersController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        void IOutputPort.UserAlreadyExists(User user) =>
            this._viewModel = this.Ok(new SignUpCustomerResponse(new UserModel(user)));

        void IOutputPort.Ok(User user) => this._viewModel = this.Ok(new SignUpCustomerResponse(new UserModel(user)));

        /// <summary>
        ///     Sign-up the current user.
        /// </summary>
        /// <response code="200">User already exists.</response>
        /// <response code="201">The user was created successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <param name="useCase">Use case.</param>
        /// <returns>The user.</returns>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(SignUpCustomerResponse))]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(SignUpCustomerResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Post))]
        public async Task<IActionResult> Post([FromServices] ISignUpUseCase useCase)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute()
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
