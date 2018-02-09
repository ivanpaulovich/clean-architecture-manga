namespace Acerola.UI.UseCases.Accounts.Close
{
    using Acerola.Application.Accounts.Close;
    using Microsoft.AspNetCore.Mvc;
    using System.Threading.Tasks;

    [Route("api/Accounts")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary input;
        private readonly Presenter presenter;

        public Controller(IInputBoundary input, Presenter presenter)
        {
            this.input = input;
            this.presenter = presenter;
        }

        /// <summary>
        /// Close the account
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Close([FromBody]Message message)
        {
            RequestModel request = new RequestModel(message.AccountId);
            await input.Handle(request);
            return presenter.ViewModel;
        }
    }
}
