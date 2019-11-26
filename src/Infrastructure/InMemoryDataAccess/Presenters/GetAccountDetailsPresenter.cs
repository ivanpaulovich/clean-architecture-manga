namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetAccountDetails;

    public sealed class GetAccountDetailsPresenter : IOutputPort
    {
        public GetAccountDetailsPresenter()
        {
            GetAccountDetails = new Collection<GetAccountDetailsOutput>();
            NotFounds = new Collection<string>();
        }

        public Collection<GetAccountDetailsOutput> GetAccountDetails { get; }

        public Collection<string> NotFounds { get; }

        public void Standard(GetAccountDetailsOutput output)
        {
            GetAccountDetails.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}