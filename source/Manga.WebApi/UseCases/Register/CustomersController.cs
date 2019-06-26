namespace Manga.WebApi.UseCases.Register
{
    using System.Threading.Tasks;
    using Manga.Application.Boundaries.Register;
    using Manga.Domain.ValueObjects;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IUseCase _registerUseCase;
        private readonly Presenter _presenter;

        public CustomersController(
            IUseCase registerUseCase,
            Presenter presenter)
        {
            _registerUseCase = registerUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] RegisterRequest request)
        {
            await _registerUseCase.Execute(new Input(
                new SSN(request.SSN),
                new Name(request.Name),
                new PositiveAmount(request.InitialAmount)));

            return _presenter.ViewModel;
        }
    }
}