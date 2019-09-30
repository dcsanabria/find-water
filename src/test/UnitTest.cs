using System;
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
        [TestCase(3, 1, 500, ExpectedResult = 0)]
        public double Given_RowAndColumn_When_ValidWaterFlow_Then_ReturnValidResult(int row, int col, double flow)
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
        [Test]

        public void Given_RowsGreaterThanColumns_When_ValidWaterFlow_Then_ReturnInvalidException()
        {
            // Arrange
            var glass = new Glass { Row = 1, Column = 2 };
            var water = new Water { Flow = 250 };
            IFindWater sut = new FindWater();

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));
            Assert.That(ex.Message, Is.EqualTo("Number of rows MUST be greater than number of rows"));
        }

        [Test]

        public void Given_NegativeRow_When_FindWaterFlow_Then_ReturnInvalidException()
        {
            // Arrange
            var glass = new Glass { Row = -1, Column = 0 };
            var water = new Water { Flow = 250 };
            IFindWater sut = new FindWater();

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));
            Assert.That(ex.Message, Is.EqualTo("Values must be greater than 0"));
        }

        [Test]

        public void Given_NegativeColumn_When_FindWaterFlow_ReturnInvalidException()
        {
            // Arrange
            var glass = new Glass { Row = 0, Column = -1 };
            var water = new Water { Flow = 250 };
            IFindWater sut = new FindWater();

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));
            Assert.That(ex.Message, Is.EqualTo("Values must be greater than 0"));
        }

        [Test]

        public void Given_NegativeWaterFlow_When_FindWaterFlow_ReturnInvalidException()
        {
            // Arrange
            var glass = new Glass { Row = 1, Column = 1 };
            var water = new Water { Flow = -1 };
            IFindWater sut = new FindWater();

            // Act
            var ex = Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));

            // Assert
            Assert.Throws<InvalidOperationException>(() => sut.FindWaterFlow(glass, water));
            Assert.That(ex.Message, Is.EqualTo("Values must be greater than 0"));
        }

    }
}
