namespace UnitTests.OpenAccount
{
    using Xunit;

    internal sealed class ValidDataSetup : TheoryData<decimal, string>
    {
        public ValidDataSetup()
        {
            this.Add(100, "SEK");
            this.Add(25, "BRL");
            this.Add(10, "USD");
        }
    }
}
