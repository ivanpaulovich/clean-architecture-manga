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

        public void Invalid(Notification notification) => this.InvalidOutput = true;

        public void NotFound() => this.NotFoundOutput = true;

        public void Ok(Account account) => this.Account = account;
    }
}
