using Logic;

namespace Game
{
    public class RandomDistibute : IDistribute
    {
        int n_players;
        public RandomDistibute(int n)
        {
            n_players = n;     
        }
        public void HandOutTokens(IEnumerable<IPlayer> players, List<Token> tokens)
        {
            //random
            IPlayer[] _players = players.ToArray(); 
            Random random = new Random();
            for (int i = 0; i < _players.Length; i++)
            {
                for (int j = 0; j < n_players; j++)
                {
                    int index = random.Next(0, tokens.Count);
                    _players[i].addToken(tokens[index]);
                    tokens.Remove(tokens[index]);

                }
            }
        }
    }
}
