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
    public class ColorBetUnitTests
    {
        [Test] // red, black, green
        public void WonAmount_FieldColorIsRedAndBetColorIsRedAndAmountEquals10_ResultEquals20()
        {
            //Arrange
            ColorBet uut = new ColorBet("Otto Leisner", 10, Field.Red); //amount = 10, color = 0
            Field testField = new Field(25, Field.Red); // Number = 25, Color = 0

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(20, returnValue);
        }

        [Test] // red, black, green
        public void WonAmount_FieldColorIsBlackAndBetColorIsBlackAndAmountEquals10_ResultEquals20()
        {
            //Arrange
            ColorBet uut = new ColorBet("Otto Leisner", 10, Field.Black); //amount = 1
            Field testField = new Field(25, Field.Black); // Number = 25

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(20, returnValue);
        }

        [Test] // red, black, green
        public void WonAmount_FieldColorIsGreenAndBetColorIsGreenAndAmountEquals10_ResultEquals20() // test for each color?
        {
            //Arrange
            ColorBet uut = new ColorBet("Otto Leisner", 10, Field.Green); //amount = 10, color = 0
            Field testField = new Field(25, Field.Green); // Number = 25, Color = 0

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(20, returnValue);
        }

        [Test]
        public void WonAmount_FieldColorDoesNotEqualBetColor_ResultEqualsZero()
        {
            //Arrange
            ColorBet uut = new ColorBet("Otto Leisner", 10, Field.Red); //amount = 10, color = 0
            Field testField = new Field(5, Field.Black); // Number = 5, Color = 1

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(0, returnValue);
        }
    }
}
