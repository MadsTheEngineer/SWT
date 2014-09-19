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
        Field redField = new Field(1, Field.Red);
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
        [ExpectedException(typeof (RouletteGameException))]
        public void PlaceBet_RoundIsClosed_RouletteGameExeption()
        {
            //Arrange

            //Act
            _uut.PlaceBet(new FakeBet());
            //Assert
            
        }
    }
}
