using System.Collections.Generic;
using TicTacToeBusiness.Models;

namespace Front.Models
{
    public class TicTacToeViewModel
    {
        public TicTacToeViewModel()
        {
            Rows = new List<List<string>>
            {
                new List<string>() { "0", "1", "2" },
                new List<string>() { "3", "4", "5" },
                new List<string>() { "6", "7", "8" }
            };

            TicTacToe = new TicTacToe();
        }

        public List<List<string>> Rows { get; set; }
        public string Result { get; set; }
        public TicTacToe TicTacToe { get; set; }
        public string Prueba { get; set; }
    }
}
