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

        public bool AddToken(Player player, int position)
        {
            if (position < 0 || position > 8)
            {
                return false;
            }

            if (Positions[position] == 0)
            {
                Positions[position] = ((int)player.Token);

                return true;
            }

            // Casilla ocupada
            return false;
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
