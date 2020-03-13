namespace ComponentTests
{
    using System;

    /// <summary>
    ///
    /// </summary>
    public sealed class CustomWebApplicationFactoryFixture : IDisposable
    {
        /// <summary>
        ///
        /// </summary>
        public CustomWebApplicationFactory CustomWebApplicationFactory { get; }

        public CustomWebApplicationFactoryFixture()
        {
            this.CustomWebApplicationFactory = new CustomWebApplicationFactory();
        }

        public void Dispose() => this.CustomWebApplicationFactory?.Dispose();
    }
}
