namespace UnitTests.Presenters
{
    using Application.Boundaries.GetCustomer;

    public sealed class GetCustomerPresenterFake : IGetCustomerOutputPort
    {
        public GetCustomerOutput? StandardOutput { get; private set; }

        public string? NotFoundOutput { get; private set; }

        public string? ErrorOutput { get; private set; }

        public void Standard(GetCustomerOutput output) => this.StandardOutput = output;

        public void NotFound(string message) => this.NotFoundOutput = message;

        public void WriteError(string message) => this.ErrorOutput = message;
    }
}
