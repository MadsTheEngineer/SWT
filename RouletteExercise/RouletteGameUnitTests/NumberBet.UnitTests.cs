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
    public class NumberBetUnitTests
    {
        [Test]
        public void WonAmount_FieldNumberEqualsBetNumberAndAmountEquals10_ResultEquals360()
        {
            //Arrange
            NumberBet uut = new NumberBet("Otto Leisner", 10, 25); //amount = 10, field number = 25
            Field testField = new Field(25, 0); // Number = 25, Color = 0

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(360, returnValue);
        }

        [Test]
        public void WonAmount_FieldNumberDoesNotEqualBetNumber_ResultEqualsZero()
        {
            //Arrange
            NumberBet uut = new NumberBet("Otto Leisner", 10, 25); //amount = 10, field number = 25
            Field testField = new Field(5, 0); // Number = 5, Color = 0

            //Act
            var returnValue = uut.WonAmount(testField);

            //Assert
            Assert.AreEqual(0, returnValue);
        }
        
        [Test]
        public void ToString_Amount10AndNumber7_10And7InsertedInString()
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
