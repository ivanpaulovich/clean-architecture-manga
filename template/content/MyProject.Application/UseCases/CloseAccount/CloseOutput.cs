namespace MyProject.Application.UseCases.CloseAccount
{
    using System;
    public class CloseOutput
    {
        public Guid AccountId { get; private set; }
        public CloseOutput()
        {

        }

        public CloseOutput(Guid accountId)
        {
            AccountId = accountId;
        }
    }
}
