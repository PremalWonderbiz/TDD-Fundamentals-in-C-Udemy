using NUnit.Framework;
using NUnit.Framework.Legacy;

namespace Example.Test
{
    //Test class name should be same as prod class name followed by Tests
    [TestFixture]
    public class ExampleProdCodeTests
    {
        //MethodName_Given_ExpectedResult
        [Test]
        public void HelloWorld_GivenDefault_ShouldReturnHelloWorld()
        {
            //Arrange
            var expected = "Hello World";
            //the thing which we are testing we have 2 options sut and or name of class which we are going to use
            var sut = new ExampleProdCode(); //sut - system under test
            
            //Act
            //for storing o/p we can use result or actual
            var actual = sut.HelloWorld();
             
            //Assert
            //Assert.AreEqual("Hello World", result);
            ClassicAssert.AreEqual(expected, actual);
        }
    }
}
