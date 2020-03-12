namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetAccountDetails;

    public sealed class GetAccountDetailsPresenter : IOutputPort
    {
        public GetAccountDetailsPresenter()
        {
            this.GetAccountDetails = new Collection<GetAccountDetailsOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<GetAccountDetailsOutput> GetAccountDetails { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(GetAccountDetailsOutput output)
        {
            this.GetAccountDetails.Add(output);
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
