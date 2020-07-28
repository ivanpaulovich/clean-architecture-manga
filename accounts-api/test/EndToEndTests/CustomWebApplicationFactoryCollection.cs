namespace EndToEndTests
{
    using Xunit;

    [CollectionDefinition("WebApi Collection")]
    public sealed class CustomWebApplicationFactoryCollection : ICollectionFixture<CustomWebApplicationFactoryFixture>
    {
    }
}
