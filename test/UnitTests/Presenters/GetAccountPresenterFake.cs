namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.GetAccount;
    using Domain.Accounts;

    public sealed class GetAccountPresenterFake : IOutputPort
    {
        public Account? Account { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid(Notification notification) => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Account account) => this.Account = account;
    }
}
