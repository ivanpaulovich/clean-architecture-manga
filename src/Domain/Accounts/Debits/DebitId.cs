namespace Domain.Accounts.Debits
{
    using System;

    public readonly struct DebitId
    {
        private readonly Guid _debitId;

        public DebitId(Guid debitId)
        {
            if (debitId == Guid.Empty)
            {
                throw new EmptyDebitIdException($"{nameof(debitId)} cannot be empty.");
            }

            this._debitId = debitId;
        }

        public override string ToString()
        {
            return this._debitId.ToString();
        }

        public Guid ToGuid() => this._debitId;
    }
}
