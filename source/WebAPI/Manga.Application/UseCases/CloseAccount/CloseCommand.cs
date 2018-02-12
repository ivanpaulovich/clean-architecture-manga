namespace Manga.Application.UseCases.CloseAccount
{
    using System;
    public class CloseCommand
    {
        public Guid AccountId { get; private set; }
        public CloseCommand(Guid guid)
        {
            this.AccountId = guid;
        }
    }
}
