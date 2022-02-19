namespace Business.Models
{
    public class Player
    {
        public Player(string name, Token token)
        {
            Name = name;
            Token = token;
        }

        public string Name { get; set; }
        public Token Token { get; set; }
    }
}
