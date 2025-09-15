using NUnit.Framework;
using NSubstitute;

namespace CharacterCopyApplication
{
    [TestFixture]
    public class CharacterCopyTests
    {
        //Test Doubles
        // - Fakes
        // - Mocks
        // - Stubs

        [TestFixture]
        public class SingleCharacterBeforeNewLine
        {
            [TestCase('a', '\n')]
            [TestCase('!', '\n')]
            [TestCase('B', '\n')]
            public void ShouldWriteThatCharacter(char firstChar, params char[] nextChars)
            {
                //Arrange
                var source = Substitute.For<ISource>();
                source.ReadChar().Returns(firstChar, nextChars);

                var destination = Substitute.For<IDestination>();

                var sut = new CharacterCopy(source, destination);

                //Act
                sut.Copy();

                //Assert 
                destination.Received(1).WriteChar(firstChar);
                destination.Received(1).WriteChar(Arg.Any<char>());
            }
        }

        [TestFixture]
        public class ManyCharacterBeforeNewLine
        {
            [TestCase('a', 'x', 'y', 'z', '\n')]
            public void ShouldWriteAllThoseCharacters(char firstChar, params char[] nextChars)
            {
                //Arrange
                var source = Substitute.For<ISource>();
                source.ReadChar().Returns(firstChar, nextChars);

                var destination = Substitute.For<IDestination>();

                var sut = new CharacterCopy(source, destination);

                //Act
                sut.Copy();

                //Assert 
                destination.Received(1).WriteChar(firstChar);
                destination.Received(1).WriteChar('x');
                destination.Received(1).WriteChar('y');
                destination.Received(1).WriteChar('z');
            }

            [TestCase('a', 'x', 'a', '\n')]
            public void GivenRepeatedCharacter_ShouldWriteAllThoseCharacters(char firstChar, params char[] nextChars)
            {
                //Arrange
                var source = Substitute.For<ISource>();
                source.ReadChar().Returns(firstChar, nextChars);

                var destination = Substitute.For<IDestination>();

                var sut = new CharacterCopy(source, destination);

                //Act
                sut.Copy();

                //Assert 
                destination.Received(2).WriteChar('a');
                destination.Received(1).WriteChar('x');
            }

            [TestCase('a', 'x', 'y', 'z', '\n')]
            public void ShouldWriteAllThoseCharactersInOrders(char firstChar, params char[] nextChars)
            {
                //Arrange
                var source = Substitute.For<ISource>();
                source.ReadChar().Returns(firstChar, nextChars);

                var destination = Substitute.For<IDestination>();

                var sut = new CharacterCopy(source, destination);

                //Act
                sut.Copy();

                //Assert 
                NSubstitute.Received.InOrder(() =>
                {
                    destination.WriteChar('a');
                    destination.WriteChar('x');
                    destination.WriteChar('y');
                    destination.WriteChar('z');
                });
            }
        }
    }
}
