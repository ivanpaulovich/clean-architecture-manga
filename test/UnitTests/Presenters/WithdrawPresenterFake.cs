namespace UnitTests.Presenters
{
    using Application.Boundaries.Withdraw;

    public sealed class WithdrawPresenterFake : IWithdrawOutputPort
    {
        public WithdrawOutput? StandardOutput { get; private set; }

        public string? NotFoundOutput { get; private set; }

        public string? OutOfBalanceOutput { get; private set; }

        public string? ErrorOutput { get; private set; }

        public void Standard(WithdrawOutput output) => this.StandardOutput = output;

        public void NotFound(string message) => this.NotFoundOutput = message;

        public void OutOfBalance(string message) => this.OutOfBalanceOutput = message;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
