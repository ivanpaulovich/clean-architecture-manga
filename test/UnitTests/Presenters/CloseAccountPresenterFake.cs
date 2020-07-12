namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.CloseAccount;
    using Domain.Accounts;

    /// <summary>
    ///     Close Account Presenter.
    /// </summary>
    public sealed class CloseAccountPresenterFake : IOutputPort
    {
        internal Account? Account { get; private set; }
        internal Notification? ModelState { get; private set; }
        internal bool NotFoundOutput { get; private set; }
        internal bool HasFundsOutput { get; private set; }

        public void Invalid(Notification modelState) => this.ModelState = modelState;

        public void NotFound() => this.NotFoundOutput = true;

        public void Ok(Account account) => this.Account = account;

        public void HasFunds() => this.HasFundsOutput = true;
    }
}
