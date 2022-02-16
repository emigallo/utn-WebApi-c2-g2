using System.Collections.Generic;

namespace CalculatorWeb.ViewModels.Home
{
    public class CalcViewModel
    {
        public CalcViewModel()
        {
            Rows = new List<List<string>>
            {
                new List<string>() { "7", "8", "9", "X" },
                new List<string>() { "4", "5", "6", "-" },
                new List<string>() { "1", "2", "3", "+" },
                new List<string>() { "0", null, ",", "=" }
            };

            Numeros = new List<int>();
        }

        public List<List<string>> Rows { get; set; }
        public List<int> Numeros { get; set; }
        public double Result { get; set; }
        public string TodoLoIngresado { get; set; }
    }
}