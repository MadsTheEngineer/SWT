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
            _uut = new Roulette();
        }

        [Test]
        public void Constructor_ResultIsFieldZero_FieldNumberIsZero()
        {
            var number =_uut.GetResult().Number;
            Assert.That(number,Is.EqualTo(0));
        }

        // Laver en fake af 
    }
}
