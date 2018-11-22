using FluentAssertions;
using Xunit;

namespace Trend.UnitTests
{
    public class DataProcessorUnitTest
    {
        [Fact]
        public void WhenDataArrayIsEmpty_ThenReturnsEmptyArray()
        {
            //Arrange
            double[] dataValues = new double[0];
            var expectedCalculatedValues = new double[0];

            //Act
            var result = DataProcessor.GetCalculatedValuesFromDataArray(dataValues, 0, 0);

            //Assert
            result.Should().BeEquivalentTo(expectedCalculatedValues);
        }

        [Fact]
        public void WhenDataArrayIsNotEmpty_ThenReturnsArray()
        {
            //Arrange
            double[] dataValues =
            {
                0.0532925166190,
                0.0516683794558,
                0.0476902537048,
                0.0413647554815,
                0.0329319946468,
                0.0228458903730,
                0.0117255663499,
                0.0002848691074,
                -0.0107496557757,
                -0.0207205601037
            };

           //Act
            var result = DataProcessor.GetCalculatedValuesFromDataArray(dataValues, 3, 10);

            //Assert
            result.Should().NotBeEmpty();
        }
    }
}
