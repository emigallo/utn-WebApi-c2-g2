using System.Collections.Generic;
using Business.Util;

namespace TicTacToeBusiness.Models
{
    public class TicTacToe
    {
        TicTacToe _ticTacToe;
        int _tokenPlayed = 0;
        public TicTacToe()
        {
            Board = new Board();

            Players = new List<Player>
            {
                new Player ("Jugador 1", Token.Cross),
                new Player ("Jugador 2", Token.Circle)
            };
        }

        private Board Board { get; set; }
        private List<Player> Players { get; set; }

        // 0 1 2 
        // 3 4 5
        // 6 7 8

        public void Start()
        {
            _ticTacToe = new TicTacToe();
        }

        public string Play(Player player, int position)
        {
            try
            {
                var message = _ticTacToe.Board.AddToken(player, position);

                _tokenPlayed++;

                if (_tokenPlayed >= 5)
                {
                    if (CheckWinner(player, _ticTacToe.Board))
                    {
                        return "El ganador es: " + player.Name;
                    }
                    if (_tokenPlayed == 9)
                    {
                        //Start();
                        return "Hubo un empate";
                    }
                }
                return message;
            }
            catch (InvalidPositionException ex)
            {
                return ex.Message;
            }
            catch (PositionHeldException ex)
            {
                return ex.Message;
            }


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
