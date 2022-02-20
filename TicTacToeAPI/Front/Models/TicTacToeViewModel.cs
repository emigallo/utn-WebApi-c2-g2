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
            Positions = new int[9];
        }
        public int[] Positions { get; set; }
        public List<List<string>> Rows { get; set; }
        public string Result { get; set; }
        public TicTacToe TicTacToe { get; set; }
        public string Prueba { get; set; }

        public string ValidToken(string item ) {

            if(Positions[System.Convert.ToInt32(item)] == 1) 
            { return "X"; };
            if (Positions[System.Convert.ToInt32(item)] == 2)
            { return "O"; };
            return "-";
        
        }
    }
}
