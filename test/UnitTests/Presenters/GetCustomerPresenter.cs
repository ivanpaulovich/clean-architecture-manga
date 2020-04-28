namespace UnitTests.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetCustomer;

    public sealed class GetCustomerPresenter : IGetCustomerOutputPort
    {
        public GetCustomerPresenter()
        {
            this.GetCustomerDetails = new Collection<GetCustomerOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<GetCustomerOutput> GetCustomerDetails { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(GetCustomerOutput output)
        {
            this.GetCustomerDetails.Add(output);
        }

        public void NotFound(string message)
        {
            this.NotFounds.Add(message);
        }

        public void WriteError(string message)
        {
            this.Errors.Add(message);
        }
    }
}
