namespace Manga.UnitTests.UseCasesTests.CloseAccount
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<decimal>
    {
        public PositiveDataSetup()
        {
            Add(0.5M);
            Add(100M);
            Add(200M);
        }
    }
}