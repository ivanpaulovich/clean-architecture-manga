namespace Manga.MvcApp.UseCases.Register
{
    using Manga.Application.UseCases.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("")]
    public sealed class AccountsController : Controller
    {
        private readonly IRegisterUseCase _registerUseCase;
        private readonly Presenter _presenter;

        public AccountsController(
            IRegisterUseCase registerUseCase,
            Presenter presenter)
        {
            _registerUseCase = registerUseCase;
            _presenter = presenter;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            if (!ModelState.IsValid)
                return View();

            RegisterOutput output = await _registerUseCase.Execute(
                request.Personnummer,
                request.Name,
                request.InitialAmount);

            _presenter.Populate(output);

            return _presenter.ViewModel;
        }
    }
}
