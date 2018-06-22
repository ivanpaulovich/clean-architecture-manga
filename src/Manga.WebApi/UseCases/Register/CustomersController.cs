namespace Manga.WebApi.UseCases.Register
{
    using Manga.Application.UseCases;
    using Manga.Application.UseCases.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IRegisterUseCase _registerUseCase;
        private readonly Presenter _presenter;

        public CustomersController(
            IRegisterUseCase registerUseCase,
            Presenter presenter)
        {
            _registerUseCase = registerUseCase;
            _presenter = presenter;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterRequest request)
        {
            RegisterOutput output = await _registerUseCase.Execute(
                request.PIN,
                request.Name,
                request.InitialAmount);

            _presenter.Populate(output);
            return _presenter.ViewModel;
        }
    }
}
