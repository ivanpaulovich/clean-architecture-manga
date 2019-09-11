namespace Manga.WebApi.UseCases.V1.Register
{
    using System.ComponentModel.DataAnnotations;
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Register;
    using Manga.Domain.ValueObjects;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Swashbuckle.AspNetCore.Examples;

    [ApiVersion("1.0")]
    [Route("api/v1/[controller]")]
    [ApiController]
    public sealed class CustomersController : Controller
    {
        private readonly IUseCase _registerUseCase;
        private readonly RegisterPresenter _presenter;

        public CustomersController(
            IUseCase registerUseCase,
            RegisterPresenter presenter)
        {
            _registerUseCase = registerUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Register a customer
        /// </summary>
        /// <response code="200">The registered customer was create successfully.</response>
        /// <response code="400">Bad request.</response>
        /// <response code="500">Error.</response>
        /// <param name="request">The request to register a customer</param>
        /// <returns>The newly registered customer</returns>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(RegisterResponse))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [SwaggerRequestExample(typeof(RegisterRequest), typeof(GetCustomerDetailsRequestExample))]
        public async Task<IActionResult> Post([FromBody][Required] RegisterRequest request)
        {
            var registerInput = new RegisterInput(
                new SSN(request.SSN),
                new Name(request.Name),
                new PositiveMoney(request.InitialAmount)
            );
            await _registerUseCase.Execute(registerInput);
            return _presenter.ViewModel;
        }
    }
}