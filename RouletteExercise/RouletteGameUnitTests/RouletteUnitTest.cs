using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame;

namespace RouletteGameUnitTests
{
    [TestFixture]
    public class RouletteUnitTest
    {
        private Roulette _uut;
        [SetUp]
        public void RunBeforeTests()
        {
            _uut = new Roulette(new FakeRandomize(0));
        }

        

        [Test]
        public void Constructor_ResultIsFieldZero_FieldNumberIsZero()
        {
            var number =_uut.GetResult().Number;
            Assert.That(number,Is.EqualTo(0));
        }

        [Test]
        public void Spin_TestingLowerBound_ReturnsFieldZero()
        {
            //Arrange
            // Setup attribute
            //Act
            _uut.Spin();
            Assert.That(_uut.GetResult().Number, Is.EqualTo(0));

        }
        [Test]
        public void Spin_TestingUpperBound_ReturnsField36()
        {
            //Arrange
            _uut = new Roulette(new FakeRandomize(36));
            //Act
            _uut.Spin();
            Assert.That(_uut.GetResult().Number, Is.EqualTo(36));

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(6)]
        [TestCase(7)]
        [TestCase(8)]
        [TestCase(9)]
        [TestCase(10)]
        [TestCase(11)]
        [TestCase(12)]
        [TestCase(13)]
        [TestCase(14)]
        [TestCase(15)]
        [TestCase(16)]
        [TestCase(17)]
        [TestCase(18)]
        [TestCase(19)]
        [TestCase(21)]
        [TestCase(20)]
        [TestCase(22)]
        [TestCase(23)]
        [TestCase(24)]
        [TestCase(25)]
        [TestCase(26)]
        [TestCase(27)]
        [TestCase(28)]
        [TestCase(29)]
        [TestCase(30)]
        [TestCase(31)]
        [TestCase(32)]
        [TestCase(33)]
        [TestCase(34)]
        [TestCase(35)]
        [TestCase(36)]
        public void Fields_HaveRightNumber_HaveRightNumber(int n)
        {
            //Arrange
            _uut = new Roulette(new FakeRandomize(n));
            //Act Spin - For at kunne tilgå det n'te felt 
            _uut.Spin();
            // Assert
            Assert.That(_uut.GetResult().Number,Is.EqualTo(n));
        }
        #region Testcases
        [TestCase(0, 2)]
        [TestCase(1, 0)]
        [TestCase(2, 1)]
        [TestCase(3, 0)]
        [TestCase(4, 1)]
        [TestCase(5, 0)]
        [TestCase(6, 1)]
        [TestCase(7, 0)]
        [TestCase(8, 1)]
        [TestCase(9, 0)]
        [TestCase(10, 1)]
        [TestCase(11, 1)]
        [TestCase(12, 0)]
        [TestCase(13, 1)]
        [TestCase(14, 0)]
        [TestCase(15, 1)]
        [TestCase(16, 0)]
        [TestCase(17, 1)]
        [TestCase(18, 0)]
        [TestCase(19, 0)]
        [TestCase(20, 1)]
        [TestCase(21, 0)]
        [TestCase(22, 1)]
        [TestCase(23, 0)]
        [TestCase(24, 1)]
        [TestCase(25, 0)]
        [TestCase(26, 1)]
        [TestCase(27, 0)]
        [TestCase(28, 1)]
        [TestCase(29, 1)]
        [TestCase(30, 0)]
        [TestCase(31, 1)]
        [TestCase(32, 0)]
        [TestCase(33, 1)]
        [TestCase(34, 0)]
        [TestCase(35, 1)]
        #endregion 
        [TestCase(36, 0)]
        public void Fields_HaveRightColor_ColorIS(int n, int c)
        {
            //Arrange
            _uut = new Roulette(new FakeRandomize(n));
            //Act Spin - For at kunne tilgå det n'te felt 
            _uut.Spin();
            // Assert
            Assert.That(_uut.GetResult().Color, Is.EqualTo(c));
        }


        // Laver en fake af Randomize
        class FakeRandomize : IRandomize
        {
            private int _returner;

            public FakeRandomize(int returner)
            {
                _returner = returner;
            }

            public int RandomInt(int from, int to)
            {
                return _returner;
            }
        }
    }
}
