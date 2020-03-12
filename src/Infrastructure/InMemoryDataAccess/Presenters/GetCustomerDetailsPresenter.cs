namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetCustomerDetails;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public GetCustomerDetailsPresenter()
        {
            this.GetCustomerDetails = new Collection<GetCustomerDetailsOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<GetCustomerDetailsOutput> GetCustomerDetails { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(GetCustomerDetailsOutput output)
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
