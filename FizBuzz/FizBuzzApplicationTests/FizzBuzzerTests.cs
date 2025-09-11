using FizBuzzApplication;
using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace FizBuzzApplicationTests
{
    //Equivalent partitions and Boundaries
    //Test cases
    //Triangulation Green Bar Pattern (Fake it, Fake it, Make it)
    [TestFixture]
    public class FizzBuzzerTests
    {
        [TestFixture]
        public class Go
        {
            [TestFixture]
            public class NumberIsDivisibleBy3
            {
                [TestCase(6)]
                [TestCase(24)]
                public void ShouldReturnsFizz(int number)
                {
                    //Arrange
                    var sut = new FizzBuzzer();
                    //Act
                    var actual = sut.Go(number);
                    //Assert
                    ClassicAssert.AreEqual("Fizz", actual);
                }
            }

            [TestFixture]
            public class NumberIsDivisibleBy5
            {
                [TestCase(20)]
                [TestCase(10)]
                public void ShouldReturnsBuzz(int number)
                {
                    //Arrange
                    var sut = new FizzBuzzer();
                    //Act
                    var actual = sut.Go(number);
                    //Assert
                    ClassicAssert.AreEqual("Buzz", actual);
                }
            }

            [TestFixture]
            public class NumberIsDivisibleBy5and3
            {
                [TestCase(15)]
                [TestCase(30)]
                public void ShouldReturnsFizzBuzz(int number)
                {
                    //Arrange
                    var sut = new FizzBuzzer();
                    //Act
                    var actual = sut.Go(number);
                    //Assert
                    ClassicAssert.AreEqual("FizzBuzz", actual);
                }
            }

            [TestFixture]
            public class NumberIsNotDivisibleBy5or3
            {
                [TestCase(1)]
                [TestCase(8)]
                public void ShouldReturnsNumberItsef(int number)
                {
                    //Arrange
                    var sut = new FizzBuzzer();
                    //Act
                    var actual = sut.Go(number);
                    //Assert
                    ClassicAssert.AreEqual(number, actual);
                }
            }

            [TestFixture]
            public class NumberIsPrime
            {
                [TestCase(2)]
                public void ShouldReturnsWhiz(int number)
                {
                    //Arrange
                    var sut = new FizzBuzzer();
                    //Act
                    var actual = sut.Go(number);
                    //Assert
                    ClassicAssert.AreEqual("Whiz", actual);
                }
            }
        }
    }
}
