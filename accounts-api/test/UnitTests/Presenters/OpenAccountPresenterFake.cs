namespace UnitTests.Presenters
{
    using Application.Services;
    using Application.UseCases.OpenAccount;
    using Domain;

    /// <summary>
    /// </summary>
    public sealed class OpenAccountPresenterFake : IOutputPort
    {
        public Account? Account { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }

        void IOutputPort.Invalid(Notification notification) => this.InvalidOutput = true;

        void IOutputPort.NotFound() => this.NotFoundOutput = true;

        void IOutputPort.Ok(Account account) => this.Account = account;
    }
}
