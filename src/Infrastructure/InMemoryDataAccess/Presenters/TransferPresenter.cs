namespace Infrastructure.InMemoryDataAccess.Presenters
{
    using System.Collections.ObjectModel;
    using Application.Boundaries.Transfer;

    public sealed class TransferPresenter : IOutputPort
    {
        public Collection<TransferOutput> Transfers { get; }
        public Collection<string> NotFounds { get; }

        public TransferPresenter()
        {
            Transfers = new Collection<TransferOutput>();
            NotFounds = new Collection<string>();
        }

        public void Standard(TransferOutput output)
        {
            Transfers.Add(output);
        }

        public void NotFound(string message)
        {
            NotFounds.Add(message);
        }
    }
}