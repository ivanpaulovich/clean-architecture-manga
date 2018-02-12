namespace Manga.UI.Requests
{
    using System;
    public class CloseRequest
    {
        public Guid AccountId { get; }

        public CloseRequest(Guid accountId)
        {
            AccountId = AccountId;
        }
    }
}
