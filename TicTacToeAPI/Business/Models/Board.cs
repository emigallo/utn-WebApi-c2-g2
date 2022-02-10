using Business.Util;
using System;
using TicTacToeBusiness.Models;

namespace TicTacToeBusiness
{
    public class Board
    {
        public Board()
        {
            Positions = new int[8];
        }

        private int[] Positions { get; set; }

        public string AddToken(Player player, int position)
        {
            if (position < 0 || position > 8)
            {
                throw new InvalidPositionException();
            }

            if (Positions[position] == 0)
            {
                Positions[position] = ((int)player.Token);

                return "Ficha colocada, turno del siguiente jugador";
            }

            // Casilla ocupada
            throw new PositionHeldException();  

        }

        public void Reset()
        {
            Positions = new int[8];
        }

        public int[] GetPositions()
        {
            return Positions;
        }
    }
}
