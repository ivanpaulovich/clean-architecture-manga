namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Transfer;

    public sealed class TransferPresenter : IOutputPort
    {
        public TransferPresenter()
        {
            this.Transfers = new Collection<TransferOutput>();
            this.NotFounds = new Collection<string>();
            this.Errors = new Collection<string>();
        }

        public Collection<TransferOutput> Transfers { get; }

        public Collection<string> NotFounds { get; }

        public Collection<string> Errors { get; }

        public void Standard(TransferOutput output)
        {
            this.Transfers.Add(output);
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
