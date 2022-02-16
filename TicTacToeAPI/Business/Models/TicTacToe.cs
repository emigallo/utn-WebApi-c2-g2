using Business.Models;
using System.Collections.Generic;
using System.Linq;

namespace TicTacToeBusiness.Models
{
    public class TicTacToe
    {
        public TicTacToe()
        {
            Board = new Board();

            Players = new List<Player>
            {
                // SIEMPRE VA A SER PAR
                new Player ("Jugador 1", Token.Cross),
                // SIEMPRE VA A SER IMPAR
                new Player ("Jugador 2", Token.Circle)
            };
        }

        // REVISAR
        public Board Board { get; set; }
        private List<Player> Players { get; init; }

        // 0 1 2 
        // 3 4 5
        // 6 7 8

        public GameStatus Play(int position)
        {
            Player player = GetNextPlayer();

            GameStatus status = Board.AddToken(player, position);
            
            if (status == GameStatus.PositionHeld || status == GameStatus.InvalidPosition)
            {
                return status;
            }
            
            return CheckGameStatus(player);
        }

        private GameStatus CheckGameStatus(Player player)
        {
            int tokensPlayed = Board.CountTokensPlayed();

            if (tokensPlayed >= 5)
            {
                if (CheckWinner(player, Board))
                {
                    return GameStatus.Winner;
                }
                if (tokensPlayed == 9)
                {
                    return GameStatus.Tie;
                }
            }

            return GameStatus.Active;
        }

        public Player GetNextPlayer()
        {
            Player player1 = Players.First();
            Player player2 = Players.Last();

            int tokenCount = Board.CountTokensPlayed();
            if ((tokenCount % 2) == 0)
            {
                return player1;
            }

            return player2;
        }

        public Player GetLastPlayer()
        {
            if (GetNextPlayer() == Players.First())
            {
                return Players.Last();
            }

            return Players.First();
        }


        public bool CheckWinner(Player lastPlayer, Board board)
        {
            int[] positions = board.GetPositions();

            // Validaciones Horizontales
            if (positions[0] == ((int)lastPlayer.Token) && positions[1] == ((int)lastPlayer.Token) && positions[2] == ((int)lastPlayer.Token))
            {
                return true;
            }

            if (positions[3] == ((int)lastPlayer.Token) && positions[4] == ((int)lastPlayer.Token) && positions[5] == ((int)lastPlayer.Token))
            {
                return true;
            }

            if (positions[6] == ((int)lastPlayer.Token) && positions[7] == ((int)lastPlayer.Token) && positions[8] == ((int)lastPlayer.Token))
            {
                return true;
            }

            // Validaciones Verticales
            if (positions[0] == ((int)lastPlayer.Token) && positions[3] == ((int)lastPlayer.Token) && positions[6] == ((int)lastPlayer.Token))
            {
                return true;
            }

            if (positions[1] == ((int)lastPlayer.Token) && positions[4] == ((int)lastPlayer.Token) && positions[7] == ((int)lastPlayer.Token))
            {
                return true;
            }

            if (positions[2] == ((int)lastPlayer.Token) && positions[5] == ((int)lastPlayer.Token) && positions[8] == ((int)lastPlayer.Token))
            {
                return true;
            }

            // Validaciones Diagonales
            if (positions[0] == ((int)lastPlayer.Token) && positions[4] == ((int)lastPlayer.Token) && positions[8] == ((int)lastPlayer.Token))
            {
                return true;
            }

            if (positions[2] == ((int)lastPlayer.Token) && positions[4] == ((int)lastPlayer.Token) && positions[6] == ((int)lastPlayer.Token))
            {
                return true;
            }

            return false;
        }
    }
}
