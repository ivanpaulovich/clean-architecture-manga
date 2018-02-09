namespace Acerola.UI.UseCases.Accounts.Close
{
    using Acerola.Application.Accounts.Close;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/Accounts")]
    public class Controller : Microsoft.AspNetCore.Mvc.Controller
    {
        private readonly IInputBoundary input;
        private readonly Presenter presenter;

        public Controller(
            IInputBoundary input,
            Presenter presenter)
        {
            if (input == null)
                throw new ArgumentNullException(nameof(input));

            if (presenter == null)
                throw new ArgumentNullException(nameof(presenter));

            this.input = input;
            this.presenter = presenter;
        }

        /// <summary>
        /// Close an account
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Close([FromBody]Message message)
        {
            Request request = new Request(message.AccountId);
            await input.Handle(request);
            Result response = presenter.Build();
            return response;
        }
    }
}
