namespace EndToEndTests;

using System;

/// <summary>
/// </summary>
public sealed class CustomWebApplicationFactoryFixture : IDisposable
{
    public CustomWebApplicationFactoryFixture() =>
        this.CustomWebApplicationFactory = new CustomWebApplicationFactory();

    /// <summary>
    /// </summary>
    public CustomWebApplicationFactory CustomWebApplicationFactory { get; }

    public void Dispose() => this.CustomWebApplicationFactory?.Dispose();
}
