using System.IO;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace Trend.UnitTests
{
    public class DataProviderUnitTest
    {
        [Fact]
        public void WhenFilenameDoesNotExists_ThenReturnsEmptyArray()
        {
            //Arrange
            var filename = "non existent file name";
            var emptyArray = new double[0];

            //Act
            var result = DataProvider.GetDataValuesFromFile(filename);

            //Assert
            result.Should().BeEquivalentTo(emptyArray);
        }

        [Fact]
        public void WhenFileWithGoodDataExists_ThenReturnsArray()
        {
            //Arrange
            string[] files = Directory.GetFiles("../../TestData/");
            var file = files.Single(f => f.Contains("FileWithValues.txt"));
            double[] expectedArray =
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
            var result = DataProvider.GetDataValuesFromFile(file);

            //Assert
            result.Should().BeEquivalentTo(expectedArray);
        }

        [Fact]
        public void WhenFileWithoutGoodDataExists_ThenReturnsEmptyArray()
        {
            //Arrange
            string[] files = Directory.GetFiles("../../TestData/");
            var      file  = files.Single(f => f.Contains("FileWithoutParseableValues.txt"));
            var emptyArray = new double[0];

            //Act
            var result = DataProvider.GetDataValuesFromFile(file);

            //Assert
            result.Should().BeEquivalentTo(emptyArray);
        }
    }
}
