namespace WebApi.UseCases.V1.Customers.GetCustomer
{
    using System.Threading.Tasks;
    using Application.UseCases.GetCustomer;
    using Domain.Customers;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Modules.Common;
    using ViewModels;

    /// <summary>
    ///     Accounts
    ///     <see href="https://github.com/ivanpaulovich/clean-architecture-manga/wiki/Design-Patterns#controller">
    ///         Controller Design Pattern
    ///     </see>
    ///     .
    /// </summary>
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public sealed class CustomersController : ControllerBase, IOutputPort
    {
        private IActionResult? _viewModel;

        void IOutputPort.NotFound() => this._viewModel = this.NotFound();

        void IOutputPort.Ok(Customer customer) =>
            this._viewModel = this.Ok(new GetCustomerResponse(new CustomerModel(customer)));

        /// <summary>
        ///     Get the Customer details.
        /// </summary>
        /// <response code="200">The Customer.</response>
        /// <response code="404">Not Found.</response>
        /// <returns>An asynchronous <see cref="IActionResult" />.</returns>
        [Authorize]
        [HttpGet(Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(GetCustomerResponse))]
        [ApiConventionMethod(typeof(CustomApiConventions), nameof(CustomApiConventions.Get))]
        public async Task<IActionResult> GetCustomer([FromServices] IGetCustomerUseCase useCase)
        {
            useCase.SetOutputPort(this);

            await useCase.Execute()
                .ConfigureAwait(false);

            return this._viewModel!;
        }
    }
}
