using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using Core.Models;
using Core.Services;
using Core.Services.Interfaces;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Constraints;
using NUnit.Framework.Internal;

namespace test
{
    [TestFixture]
    public class UnitTest
    {

        [Test]
        public async Task Given_RowGreaterThanColumn_Then_ReturnZero()
        {
            // Arrange
            var glass = new Glass { Row = 2, Column = 1 };
            var water = new Water { Flow = 500 };
            IFindWater sut = new FindWater();

            // Act
            var expectedResult = await sut.FindWaterFlow(glass, water);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(0));
        }

        [Test]
        public async Task Given_GlassRow0Column0_When_Water200_Then_Return200()
        {
            // Arrange
            var glass = new Glass { Row = 0, Column = 0 };
            var water = new Water { Flow = 200 };
            IFindWater sut = new FindWater();

            // Act
            var expectedResult = await sut.FindWaterFlow(glass, water);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(200));
        }

        [Test]
        public async Task Given_GlassRow0Column0_When_Water250_Then_Return250()
        {
            // Arrange
            var glass = new Glass { Row = 0, Column = 0 };
            var water = new Water { Flow = 250 };
            IFindWater sut = new FindWater();

            // Act
            var expectedResult = await sut.FindWaterFlow(glass, water);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(250));
        }

        [Test]
        public async Task Given_GlassRow0Column0_When_Water500_Then_Return250()
        {
            // Arrange
            var glass = new Glass { Row = 0, Column = 0 };
            var water = new Water { Flow = 500 };
            IFindWater sut = new FindWater();

            // Act
            var expectedResult = await sut.FindWaterFlow(glass, water);

            // Assert
            Assert.That(expectedResult, Is.EqualTo(250));
        }



    }
}
