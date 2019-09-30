using Core.Models;
using Core.Services;
using Core.Services.Interfaces;
using NUnit.Framework;

namespace test
{
    [TestFixture]
    public class UnitTest
    {
        [TestCase(0, 0, 200, ExpectedResult = 200)]
        [TestCase(0, 0, 250, ExpectedResult = 250)]
        [TestCase(0, 0, 500, ExpectedResult = 250)]
        [TestCase(1, 0, 500, ExpectedResult = 125)]
        [TestCase(1, 1, 500, ExpectedResult = 125)]
        [TestCase(2, 1, 500, ExpectedResult = 125)]
        public double Given_RowAndColumn_WhenValidWaterFlow_Then_ReturnValidResult(int row, int col, double flow)
        {
            // Arrange
            var glass = new Glass { Row = row, Column = col };
            var water = new Water { Flow = flow };
            IFindWater sut = new FindWater();

            // Act
            var expectedResult = sut.FindWaterFlow(glass, water);

            // Assert
            return expectedResult;
        }
    }
}
