namespace UnitTests.UseCaseTests.Register
{
    using Xunit;

    internal sealed class ValidDataSetup : TheoryData<decimal>
    {
        public ValidDataSetup()
        {
            this.Add(0);
            this.Add(100);
            this.Add(200);
        }
    }
}
