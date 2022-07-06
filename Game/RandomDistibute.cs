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
        public void HandOutTokens(Player[] players, List<IToken> tokens)
        {
            //random

            Random random = new Random();
            for (int i = 0; i < players.Length; i++)
            {
                for (int j = 0; j < n_players; j++)
                {
                    int index = random.Next(0, tokens.Count);
                    players[i].tokens.Add(tokens[index]);
                    tokens.Remove(tokens[index]);

                }
            }
        }
    }
}
