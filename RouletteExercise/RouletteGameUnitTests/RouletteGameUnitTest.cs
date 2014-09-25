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
        private FakeRoulette _fakeRoulette;
        private FakeOutputDevice _fakeOutputDevice;
        [SetUp]
        public void RunBeforeTests()
        {
            _fakeRoulette = new FakeRoulette();
            _fakeOutputDevice = new FakeOutputDevice();
            _uut = new RouletteGameClass(_fakeRoulette,_fakeOutputDevice);
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

        class FakeOutputDevice : IOutputDevice
        {
            public string ReceivedString { get; set; }
            public int TimesCalled { get; set;}
            public void Render(string format, params object[] arguments)
            {
                ReceivedString = String.Format(format, arguments);
                TimesCalled++;
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
        public void CloseBets_RoundIsClosed_RouletteGameExeption()
        {
            //Arrange

            //Act
            _uut.OpenBets();
            _uut.CloseBets();
            //Assert
            Assert.That(() => _uut.PlaceBet(new FakeBet()), Throws.TypeOf<RouletteGameException>());
        }

        [Test]
        public void OpenBets_OpenBets_RenderCalled()
        {
            //Arrange
            //Act
            _uut.OpenBets();
            //Assert
            Assert.That(_fakeOutputDevice.TimesCalled,Is.EqualTo(1));
        }
    }
}
