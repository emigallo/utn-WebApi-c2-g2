using Business.Models;
using System;
using System.Collections.Generic;

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

        public List<List<string>> Rows { get; set; }
        public TicTacToe TicTacToe { get; set; }
        public int[] Positions { get; set; }
        public string Result { get; set; }

        public string ValidToken(string item) {

            if(Positions[Convert.ToInt32(item)] == 1) 
            { 
                return "X"; 
            };
            
            if (Positions[Convert.ToInt32(item)] == 2)
            {
                return "O"; 
            };
            
            return "-";        
        }
    }
}
