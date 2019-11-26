namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetCustomerDetails;

    public sealed class GetCustomerDetailsPresenter : IOutputPort
    {
        public GetCustomerDetailsPresenter()
        {
            GetCustomerDetails = new Collection<GetCustomerDetailsOutput>();
            NotFounds = new Collection<string>();
        }

        public Collection<GetCustomerDetailsOutput> GetCustomerDetails { get; }

        public Collection<string> NotFounds { get; }

        public void Standard(GetCustomerDetailsOutput output)
        {
            GetCustomerDetails.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}