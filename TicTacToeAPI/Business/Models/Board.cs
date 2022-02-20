using Business.Models;
using TicTacToeBusiness.Models;

namespace TicTacToeBusiness
{
    public class Board
    {
        public Board()
        {
            Positions = new int[9];
        }

        public int[] Positions { get; set; }

        public GameStatus AddToken(Player player, int position)
        {
            if (position < 0 || position > 8)
            {
                return GameStatus.InvalidPosition;
            }

            if (Positions[position] == 0)
            {
                Positions[position] = ((int)player.Token);

                return GameStatus.Active;
            }

            return GameStatus.PositionHeld;  
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
