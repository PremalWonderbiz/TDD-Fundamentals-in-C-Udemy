using NUnit.Framework;
using NUnit.Framework.Legacy;
using StringCalculatorApplication;

namespace StringCalculatorApplicationTests
{
    [TestFixture]
    public class StringCalculatorTests
    {
        [TestFixture]
        public class OneNumber
        {
            [TestCase("1", 1)]
            [TestCase("23", 23)]
            [TestCase("99", 99)]
            public void ShouldReturnThatNumber(string number, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(number);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
        
        [TestFixture]
        public class NoNumbers
        {
            [TestCase("", 0)]
            [TestCase("  ", 0)]
            [TestCase("       ", 0)]
            [TestCase(null, 0)]
            public void ShouldReturnZero(string number, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(number);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
        
        [TestFixture]
        public class ManyNumbers
        {
            [TestCase("1,2", 3)]
            [TestCase("20,10,7", 37)]
            [TestCase("999,1,20,13", 1033)]
            public void ShouldReturnSumOfThoseNumbers(string number, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(number);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
        
        [TestFixture]
        public class ManyNumbersSeperatedByNewLineOrComma
        {
            [TestCase("1\n2,3", 6)]
            [TestCase("20\n10\n30\n40", 100)]
            [TestCase("5\n5", 10)]
            public void ShouldReturnSumOfThoseNumbers(string number, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(number);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class CustomDelimiters
        {
            [TestCase("//;\n1;2", 3)]
            [TestCase("//|\n40|20,10\n10", 80)]
            [TestCase("//|\n999,1|2\n8", 1010)]
            public void ShouldReturnSumOfNumbersInString(string number, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(number);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
        
        [TestFixture]
        public class NegativeNumbers
        {
            [TestCase("-1", "Negatives not allowed : -1")]
            [TestCase("10,-10,24", "Negatives not allowed : -10")]
            public void GivenOneNegative_ShouldThrowAnExceptionWithNegativeInMessage(string input, string expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var exception = Assert.Throws<Exception>(() => sut.Add(input)) ;
                //Assert
                ClassicAssert.NotNull(exception);
                ClassicAssert.AreEqual(expected, exception?.Message);
            }
            
            [TestCase("-1,8,-34,45,-4", "Negatives not allowed : -1,-34,-4")]
            [TestCase("10,-10,24,-999", "Negatives not allowed : -10,-999")]
            public void GivenMultipleNegative_ShouldThrowAnExceptionWithAllNegativesInMessage(string input, string expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var exception = Assert.Throws<Exception>(() => sut.Add(input)) ;
                //Assert
                ClassicAssert.NotNull(exception);
                ClassicAssert.AreEqual(expected, exception?.Message);
            } 
        }
        
        [TestFixture]
        public class NumbersGreaterThanThousand
        {
            [TestCase("2002", 0)]
            [TestCase("10,3002,40,2048", 50)]
            [TestCase("1,5033,2,3432,5", 8)]
            public void ShouldBeIgnoredInSum(string input, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(input);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }

        [TestFixture]
        public class LongLengthMultipleCustomDelimiters
        {
            [TestCase("//[***][;][,][$]\n1;2,3$4***10\n30", 50)]
            [TestCase("//[*][;][,][$][%%][####][...]\n1,2;3####4*5%%6...7", 28)]
            public void ShouldReturnSumOfNumbersInString(string number, int expected)
            {
                //Arrange
                var sut = new StringCalculator();
                //Act
                var actual = sut.Add(number);
                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
    }
}
