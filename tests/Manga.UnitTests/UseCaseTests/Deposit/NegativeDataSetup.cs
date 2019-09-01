namespace Manga.UnitTests.UseCasesTests.Deposit
{
    using Xunit;

    internal sealed class NegativeDataSetup : TheoryData<double>
    {
        public NegativeDataSetup()
        {
            Add(-100);
        }
    }
}