namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.GetAccount;

    public sealed class GetAccountPresenter : IGetAccountOutputPort
    {
        public GetAccountPresenter()
        {
            this.GetAccountDetails = new Collection<GetAccountOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<GetAccountOutput> GetAccountDetails { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(GetAccountOutput output)
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
