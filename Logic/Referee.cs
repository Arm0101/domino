
namespace Logic
{

    public class Referee
    {

        private List<Token<int>> tokens;
        public List<Token<int>> Tokens { get { return tokens; } }
        private Player[] players;
        public Referee() { tokens = new List<Token<int>>(); }

        public void handOutTokens(List<Token<int>> _tokens, int n_players)
        {
            //random
            tokens = _tokens;   
            players = new Player[n_players];
            Random  random = new Random();

            //inicializar jugadores
            for (int i = 0; i < n_players; i++)
            {
                players[i] = new Player();
                players[i].Tokens = new List<Token<int>>();
            }
            
            for (int i = 0; i < n_players ; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int index =  random.Next(0, tokens.Count);
                    players[i].Tokens.Add(tokens[index]);
                    tokens.Remove(tokens[index]);
                }
            }
            
        }
        

    }
}
