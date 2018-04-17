namespace MyProject.WebApi.UseCases.Register
{
    using MyProject.Application;
    using MyProject.Application.UseCases.Register;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary<RegisterInput> registerInput;
        private readonly Presenter registerPresenter;

        public CustomersController(
            IInputBoundary<RegisterInput> registerInput,
            Presenter registerPresenter)
        {
            this.registerInput = registerInput;
            this.registerPresenter = registerPresenter;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterRequest message)
        {
            var request = new RegisterInput(message.PIN, message.Name, message.InitialAmount);
            await registerInput.Process(request);
            return registerPresenter.ViewModel;
        }
    }
}
