namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetCustomerDetails;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public Collection<GetCustomerDetailsOutput> GetCustomerDetails { get; }
        public Collection<string> NotFounds { get; }

        public GetCustomerDetailsPresenter()
        {
            GetCustomerDetails = new Collection<Application.Boundaries.GetCustomerDetails.GetCustomerDetailsOutput>();
            NotFounds = new Collection<string>();
        }

        public void Standard(Application.Boundaries.GetCustomerDetails.GetCustomerDetailsOutput output)
        {
            GetCustomerDetails.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}