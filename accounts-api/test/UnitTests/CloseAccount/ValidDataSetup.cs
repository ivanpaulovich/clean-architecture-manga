namespace UnitTests.CloseAccount;

using Xunit;

internal sealed class ValidDataSetup : TheoryData<decimal>
{
    public ValidDataSetup()
    {
        this.Add(0.5M);
        this.Add(100M);
        this.Add(200M);
    }
}
