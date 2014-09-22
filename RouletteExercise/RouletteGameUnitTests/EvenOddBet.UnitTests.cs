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
    public class EvenOddBetUnitTests
    {
        [Test]
        public void WonAmount_BetOnEvenIsCorrectAndAmountEquals10_ResultEquals20()
        {
            //Arrange
            EvenOddBet uut = new EvenOddBet("Otto Leisner", 10, true); //amount = 10, even = true
            Field testField = new Field(2, 0); // Number = 25, Color = 0

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(20, returnValue);
        }

        [Test]
        public void WonAmount_BetOnOddIsCorrectAndAmountEquals10_ResultEquals20()
        {
            //Arrange
            EvenOddBet uut = new EvenOddBet("Otto Leisner", 10, false); //amount = 10, even = false
            Field testField = new Field(3, 0); // Number = 3, Color = 0

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(20, returnValue);
        }

        [Test]
        public void WonAmount_BetOnOddIsIncorrect_ResultEqualsZero()
        {
            //Arrange
            EvenOddBet uut = new EvenOddBet("Otto Leisner", 10, false); //amount = 10, even = false
            Field testField = new Field(2, 1); // Number = 2, Color = 1

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(0, returnValue);
        }

        [Test]
        public void WonAmount_BetOnEvenIsIncorrect_ResultEqualsZero()
        {
            //Arrange
            EvenOddBet uut = new EvenOddBet("Otto Leisner", 10, true); //amount = 10, even = true
            Field testField = new Field(3, 1); // Number = 2, Color = 1

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(0, returnValue);
        }

        [Test]
        public void ToString_ColorInsertedInString()
        {
            //Arrange
            NumberBet uut = new NumberBet("Otto Leisner", 10, 7); //amount = 10, field number =7            

            //Act
            var returnValue = uut.ToString();

            //Assert
            Assert.AreEqual("10$ field bet on 7", returnValue);
        }
    }
}
