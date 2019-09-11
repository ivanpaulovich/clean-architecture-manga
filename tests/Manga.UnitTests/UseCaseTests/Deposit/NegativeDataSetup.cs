namespace Manga.UnitTests.UseCasesTests.Deposit
{
    using Xunit;

    internal sealed class NegativeDataSetup : TheoryData<decimal>
    {
        public NegativeDataSetup()
        {
            Add(-100);
        }
    }
}