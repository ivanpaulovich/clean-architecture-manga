namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.GetAccount;
    using Domain;

    public sealed class GetAccountPresenterFake : IOutputPort
    {
        public Account? Account { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }

        void IOutputPort.Invalid(Notification notification) => this.InvalidOutput = true;
        void IOutputPort.NotFound() => this.NotFoundOutput = true;
        void IOutputPort.Ok(Account account) => this.Account = account;
    }
}
