namespace Manga.UnitTests.UseCasesTests.CloseAccount
{
    using Xunit;

    internal sealed class PositiveDataSetup : TheoryData<double>
    {
        public PositiveDataSetup()
        {
            Add(0.5);
            Add(100);
            Add(200);
        }
    }
}