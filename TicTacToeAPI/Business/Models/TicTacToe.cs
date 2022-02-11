using System.Collections.Generic;
using System.Linq;
using Business.Util;

namespace TicTacToeBusiness.Models
{
    public class TicTacToe
    {

        public TicTacToe()
        {
            Board = new Board();

            Players = new List<Player>
            {
                //SIEMPRE VA A SER PAR
                new Player ("Jugador 1", Token.Cross),
                //SIEMPRE VA A SER IMPAR
                new Player ("Jugador 2", Token.Circle)
            };
        }

        private Board Board { get; set; }
        private List<Player> Players { get; set; }

        // 0 1 2 
        // 3 4 5
        // 6 7 8

        public int Play(Player player, int position)
        {
            try
            {
                Board.AddToken(player, position);
            }
            catch (InvalidPositionException)
            {
                return 4;
            }
            catch (PositionHeldException)
            {
                return 5;
            }

            int tokensPlayed = Board.CountTokensPlayed();

            if (tokensPlayed >= 5)
            {
                if (CheckWinner(player, Board))
                {
                    if ((int)player.Token == 1)
                    {
                        //GANO CROSS
                        return 1;
                    }
                    //GANO CIRCULO
                    return 3;
                }
                if (tokensPlayed == 9)
                {
                    //HUBO UN EMPATE
                    return 2;
                }
            }
            //SIGUE EL JUEGO
            return 0;
        }

        public Player GetNextPlayer()
        {
            var player1 = Players.First();
            var player2 = Players.Last();

            int tokenCount = Board.CountTokensPlayed();
            if ((tokenCount % 2) == 0)
            {
                return player1;
            }

            return player2;
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

        //PREGUNTA A EMI POR LE NOMBRE
        //public bool CheckTie(Board board)
        //{
        //    int[] posiciones = board.GetPositions();

        //    foreach (int item in posiciones)
        //    {
        //        if (item == 0)
        //        {
        //            return false;
        //        }
        //    }

        //    return true;
        //}
    }
}
