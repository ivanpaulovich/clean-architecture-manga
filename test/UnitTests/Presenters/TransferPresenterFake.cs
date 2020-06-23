namespace UnitTests.Presenters
{
    using Application.Boundaries.Transfer;

    public sealed class TransferPresenterFake : ITransferOutputPort
    {
        public TransferOutput? TransferOutput { get; private set; }

        public string? NotFoundOutput { get; private set; }

        public string? ErrorOutput { get; private set; }

        public void Standard(TransferOutput output) => this.TransferOutput = output;

        public void NotFound(string message) => this.NotFoundOutput = message;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
