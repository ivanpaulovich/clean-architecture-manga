namespace Manga.Domain.ValueObjects
{
    public class Amount
    {
        public double Value { get; private set; }

        public Amount(double value)
        {
            if (value < 0)
                throw new AmountShouldBePositiveException($"Amount should be greater than zero ({value}).");

            this.Value = value;
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        public static Amount operator +(Amount amount1, Amount amount2)
        {
            return new Amount(amount1.Value + amount2.Value);
        }

        public static Amount operator -(Amount amount1, Amount amount2)
        {
            return new Amount(amount1.Value - amount2.Value);
        }

        public static bool operator <(Amount amount1, Amount amount2)
        {
            return amount1.Value < amount2.Value;
        }

        public static bool operator >(Amount amount1, Amount amount2)
        {
            return amount1.Value > amount2.Value;
        }

        public static bool operator <=(Amount amount1, Amount amount2)
        {
            return amount1.Value <= amount2.Value;
        }

        public static bool operator >=(Amount amount1, Amount amount2)
        {
            return amount1.Value >= amount2.Value;
        }
    }
}
