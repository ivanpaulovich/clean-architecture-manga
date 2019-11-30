namespace Domain.Accounts.Credits
{
    using System;

    public readonly struct CreditId
    {
        private readonly Guid _creditId;

        public CreditId(Guid creditId)
        {
            if (creditId == Guid.Empty)
            {
                throw new EmptyCreditIdException($"{nameof(creditId)} cannot be empty.");
            }

            _creditId = creditId;
        }

        public override string ToString()
        {
            return _creditId.ToString();
        }

        public Guid ToGuid() => _creditId;
    }
}
