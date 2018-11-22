using FluentAssertions;
using Xunit;

namespace Trend.UnitTests
{
    public class DataFormatterUnitTest
    {
        private const string NoValuesProvided = "No data values were provided for formatting.";

        [Fact]
        public void WhenNoValuesProvided_ThenReturnsNoValuesProvided()
        {
            //Arrange
            double[] dataValues = new double[0];

            //Act
            var result = DataFormatter.GetValuesFormattedAsMatrix(0, dataValues);

            //Assert
            result.Should().BeEquivalentTo(NoValuesProvided);
        }

        [Fact]
        public void WhenValuesAreProvided_ThenReturnsSomething()
        {
            //Arrange
            double[] dataValues = {0.1, 0.2, 0.3, 0.4, 0.5};

            //Act
            var result = DataFormatter.GetValuesFormattedAsMatrix(0, dataValues);

            //Assert
            result.Should().NotBe(NoValuesProvided);
        }
    }
}
