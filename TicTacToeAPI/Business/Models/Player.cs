namespace TicTacToeBusiness.Models
{
    public class Player
    {
        public Player(string name, Token token)
        {
            Name = name;
            Token = token;
        }

        private string Name { get; set; }
        public Token Token { get; set; }
    }
}
