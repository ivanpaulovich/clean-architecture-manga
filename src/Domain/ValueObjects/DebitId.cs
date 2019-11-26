namespace Domain.ValueObjects
{
    using System;

    public readonly struct DebitId
    {
        private readonly Guid _debitId;

        public DebitId(Guid debitId)
        {
            if (debitId == Guid.Empty)
            {
                throw new EmptyCreditIdException($"{nameof(debitId)} cannot be empty.");
            }

            _debitId = debitId;
        }

        public override string ToString()
        {
            return _debitId.ToString();
        }

        public Guid ToGuid() => _debitId;
    }
}