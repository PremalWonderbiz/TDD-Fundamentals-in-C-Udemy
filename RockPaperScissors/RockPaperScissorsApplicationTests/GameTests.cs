

using NUnit.Framework;
using NUnit.Framework.Legacy;
using RockPaperScissorsApplication;
using RockPaperScissorsApplication.Enums;

namespace RockPaperScissorsApplicationTests
{
    //1. You are not allowed to write any production code unless it is to make a failing unit test pass.
    //2. You are not allowed to write any more of a unit test than is sufficient to fail, and compilation
    //failures are failures.
    //3. You are not allowed to write any more production code than is sufficient to pass the one failing
    //unit test.

    [TestFixture]
    public class GameTests
    {
        [TestFixture]
        public class Play
        {
            [TestFixture]
            public class PaperBeatsRock
            {
                [Test]
                public void GivenPlayerPaper_OpponentRock_ShouldReturnPlayerWins()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Paper, PlayerMoves.Rock);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.PlayerWins, actual);
                }

                [Test]
                public void GivenPlayerRock_OpponentPaper_ShouldReturnPlayerLoses()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Rock, PlayerMoves.Paper);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.PlayerLoses, actual);
                }
            }

            [TestFixture]
            public class RockBeatsScissors
            {
                [Test]
                public void GivenPlayerRock_OpponentScissors_ShouldReturnPlayerWins()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Rock, PlayerMoves.Scissors);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.PlayerWins, actual);
                }
                
                [Test]
                public void GivenPlayerScissors_OpponentRock_ShouldReturnPlayerLoses()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Scissors, PlayerMoves.Rock);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.PlayerLoses, actual);
                }
            }
            
            [TestFixture]
            public class ScissorsBeatsPapaer
            {
                [Test]
                public void GivenPlayerScissors_OpponentPaper_ShouldReturnPlayerWins()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Scissors, PlayerMoves.Paper);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.PlayerWins, actual);
                }
                
                [Test]
                public void GivenPlayerPaper_OpponentScissors_ShouldReturnPlayerLoses()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Paper, PlayerMoves.Scissors);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.PlayerLoses, actual);
                }
            }
            
            [TestFixture]
            public class Tie
            {
                [Test]
                public void GivenPlayerScissors_OpponentScissors_ShouldReturnTie()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Scissors, PlayerMoves.Scissors);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.Tie, actual);
                }

                [Test]
                public void GivenPlayerPaper_OpponentPaper_ShouldReturnTie()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Paper, PlayerMoves.Paper);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.Tie, actual);
                }

                [Test]
                public void GivenPlayerRock_OpponentRock_ShouldReturnTie()
                {
                    //Arrange
                    var sut = CreateGame();
                    //Act
                    var actual = sut.Play(PlayerMoves.Rock, PlayerMoves.Rock);
                    //Assert
                    ClassicAssert.AreEqual(Outcomes.Tie, actual);
                }
            }
        }

        private static Game CreateGame()
        {
            return new Game();
        }
    }
}
