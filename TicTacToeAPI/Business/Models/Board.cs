using Business.Util;
using System;
using TicTacToeBusiness.Models;

namespace TicTacToeBusiness
{
    public class Board
    {
        public Board()
        {
            Positions = new int[9];
        }

        private int[] Positions { get; set; }

        public bool AddToken(Player player, int position)
        {
            if (position < 0 || position > 8)
            {
                throw new InvalidPositionException();
            }

            if (Positions[position] == 0)
            {
                Positions[position] = ((int)player.Token);

                return true;
            }

            // Casilla ocupada
            throw new PositionHeldException();  
        }

        public void Reset()
        {
            Positions = new int[9];
        }

        public int CountTokensPlayed()
        {
            int countTokens = 0;
            foreach (int item in Positions)
            {
                if(item != 0)
                {
                    countTokens++;
                }
            }
            return countTokens;
        }

        public int[] GetPositions()
        {

            return Positions;
        }
    }
}
