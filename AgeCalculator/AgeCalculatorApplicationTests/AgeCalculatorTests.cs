using NUnit.Framework;
using AgeCalculatorApplication;
using NUnit.Framework.Legacy;

namespace AgeCalculatorApplicationTests
{
    //3 stages of naming : Meaningless -> Specific -> Meaningful -> Generals
    [TestFixture]
    public class AgeCalculatorTests
    {
        [TestFixture]
        public class OnBirthDay
        {
            [TestCase("2002/10/31", "2025/10/31", 23)]
            [TestCase("2000/02/29", "2004/02/29", 4)]  //leap year scenario
            public void ShouldReturnDiffereneInYears(DateTime birthDate, DateTime targetDate, int expected)
            {
                //Arrange
                var sut = new AgeCalculator();
                //Act
                var actual = sut.GetAge(birthDate, targetDate);

                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
        
        [TestFixture]
        public class AfterBirthDay
        {
            [TestCase("2003/01/10", "2024/02/05", 21)]
            [TestCase("2010/01/10", "2020/02/05", 10)]
            [TestCase("2000/02/29", "2004/03/25", 4)]  //leap year scenario
            public void ShouldReturnDiffereneInYears(DateTime birthDate, DateTime targetDate, int expected)
            {
                //Arrange
                var sut = new AgeCalculator();
                //Act
                var actual = sut.GetAge(birthDate, targetDate);

                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }
        
        [TestFixture]
        public class BeforeBirthDay
        {
            [TestCase("2000/06/10", "2020/03/05", 19)]
            [TestCase("2002/10/31", "2025/09/11", 22)]
            [TestCase("2002/01/31", "2025/01/20", 22)]
            [TestCase("2000/02/29", "2004/02/28", 3)] //leap year scenario
            public void ShouldReturnDiffereneInYearsMinusOne(DateTime birthDate, DateTime targetDate, int expected)
            {
                //Arrange
                var sut = new AgeCalculator();
                //Act
                var actual = sut.GetAge(birthDate, targetDate);

                //Assert
                ClassicAssert.AreEqual(expected, actual);
            }
        }        
    }
}
