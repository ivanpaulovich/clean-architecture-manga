namespace Manga.Domain.Tests
{
    using Manga.Domain.ValueObjects;
    using Xunit;

    public class SSNTests
    {
        [Fact]
        public void Empty_SSN_Should_Not_Be_Created()
        {
            //
            // Arrange
            string empty = string.Empty;

            //
            // Act and Assert
            Assert.Throws<SSNShouldNotBeEmptyException>(
                () => new SSN(empty));
        }

        [Fact]
        public void Valid_SSN_Should_Be_Created()
        {
            //
            // Arrange
            string valid = "08724050601";

            //
            // Act
            SSN SSN = new SSN(valid);

            // Assert
            Assert.Equal(valid, SSN);
        }
    }
}
