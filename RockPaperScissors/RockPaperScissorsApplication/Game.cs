
using RockPaperScissorsApplication.Enums;

namespace RockPaperScissorsApplication
{
    public class Game
    {
        private List<(PlayerMoves, PlayerMoves)> winningScenarios = new()
        {
            (PlayerMoves.Rock, PlayerMoves.Scissors),
            (PlayerMoves.Scissors, PlayerMoves.Paper),
            (PlayerMoves.Paper, PlayerMoves.Rock)
        };

        public object Play(PlayerMoves playerMove, PlayerMoves opponentMove)
        {
            var scenario = (playerMove, opponentMove);
            return playerMove == opponentMove ? Outcomes.Tie : winningScenarios.Contains(scenario) ? Outcomes.PlayerWins : Outcomes.PlayerLoses;  
        }
    }
}
