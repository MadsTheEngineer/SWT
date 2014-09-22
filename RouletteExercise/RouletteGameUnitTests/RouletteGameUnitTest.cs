using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using RouletteGame;
using RouletteGameClass = RouletteGame.RouletteGame;

namespace RouletteGameUnitTests
{
    [TestFixture]
    public class RouletteGameUnitTest
    {
        private RouletteGameClass _uut;
        [SetUp]
        public void RunBeforeTests()
        {
            _uut = new RouletteGameClass(new FakeRoulette());
        }

        //Fields to return
        Field greenAndEvenField = new Field(0, Field.Green);
        Field redAndUnevenField = new Field(1, Field.Red);
        Field blackAndEvenField = new Field(2, Field.Black);
        class FakeRoulette : IRoulette
        {
            Field ReturnField { get; set; }
            public void Spin(){}

            public Field GetResult()
            {
                return ReturnField;
            }
        }

        class FakeBet : IBet
        {
            public string PlayerName { get; private set; }
            public uint Amount { get; private set; }
            public uint WonAmount(Field field)
            {
                throw new NotImplementedException();
            }
        }

        [Test]
        public void PlaceBet_RoundIsClosedAsDefault_RouletteGameExeption()
        {
            //Arrange

            //Act

            //Assert
            Assert.That( () => _uut.PlaceBet(new FakeBet()), Throws.TypeOf<RouletteGameException>());
        }

        [Test]
        public void PlaceBet_RoundIsOpen_NoExeption()
        {
            //Arrange

            //Act
            _uut.OpenBets();
            //Assert
            Assert.That( () => _uut.PlaceBet(new FakeBet()), Throws.Nothing);
        }

        [Test]
        public void PlaceBet_RoundIsClosed_RouletteGameExeption()
        {
            //Arrange

            //Act
            _uut.OpenBets();
            _uut.CloseBets();
            //Assert
            Assert.That(() => _uut.PlaceBet(new FakeBet()), Throws.TypeOf<RouletteGameException>());
        }
    }
}
