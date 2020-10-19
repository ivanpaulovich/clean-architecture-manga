namespace Application.UseCases.OpenAccount
{
    using Domain;

    /// <summary>
    /// </summary>
    public sealed class OpenAccountPresenter : IOutputPort
    {
        public Account? Account { get; private set; }
        public bool InvalidOutput { get; private set; }
        public bool NotFoundOutput { get; private set; }
        public void Invalid() => this.InvalidOutput = true;
        public void NotFound() => this.NotFoundOutput = true;
        public void Ok(Account account) => this.Account = account;
    }
}
