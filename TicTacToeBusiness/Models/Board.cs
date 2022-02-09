using System.Collections.Generic;

namespace TicTacToeBusiness
{
    public class Board
    {
        public Board()
        {
            myBoard = new char[3, 3];

            Rows = new List<List<char>>
            {
                new List<char>() { ' ', ' ', ' ' },
                new List<char>() { ' ', ' ', ' ' },
                new List<char>() { ' ', ' ', ' ' }
            };
        }

        // 1
        private char[,] myBoard;

        // 2
        public List<List<char>> Rows { get; set; }

        // 3
        public List<int> Positions { get; set; }
    }
}
