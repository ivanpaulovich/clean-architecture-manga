namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.CloseAccount;
    using Domain;

    /// <summary>
    ///     Close Account Presenter.
    /// </summary>
    public sealed class CloseAccountPresenterFake : IOutputPort
    {
        internal Account? Account { get; private set; }
        internal Notification? ModelState { get; private set; }
        internal bool NotFoundOutput { get; private set; }
        internal bool HasFundsOutput { get; private set; }

        void IOutputPort.Invalid(Notification modelState) => this.ModelState = modelState;

        void IOutputPort.NotFound() => this.NotFoundOutput = true;

        void IOutputPort.Ok(Account account) => this.Account = account;

        void IOutputPort.HasFunds() => this.HasFundsOutput = true;
    }
}
