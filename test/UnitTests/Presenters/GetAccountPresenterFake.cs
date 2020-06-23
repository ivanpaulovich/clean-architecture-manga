namespace UnitTests.Presenters
{
    using Application.Boundaries.GetAccount;

    public sealed class GetAccountPresenterFake : IGetAccountOutputPort
    {
        public GetAccountOutput? StandardOutput { get; private set; }
        public string? NotFoundOutput { get; private set; }
        public string? ErrorOutput { get; private set; }

        public void Standard(GetAccountOutput output) => this.StandardOutput = output;

        public void NotFound(string message) => this.NotFoundOutput = message;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
