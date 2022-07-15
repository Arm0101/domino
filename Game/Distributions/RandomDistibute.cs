using Logic;

namespace Game
{
    public class RandomDistibute : IDistribute
    {
        int n_players; //cantidad de fichas por jugadores
        public string Description() => "Se distribuyen fichas de manera aleatoria";
        public RandomDistibute(int n)
        {
            n_players = n;
        }
        public void HandOutTokens(IEnumerable<IPlayer> players, List<Token> tokens)
        {
            //random
            Random random = new Random();
            foreach (IPlayer player in players)// recorrer los jugadores
            {
                for (int j = 0; j < n_players; j++) // agregar n fichas
                {
                    //se obtiene una ficha aleatoria y se le agrega al jugador i
                    int index = random.Next(0, tokens.Count);
                    if (tokens.Count == 0) return;
                    player.addToken(tokens[index]);
                    tokens.Remove(tokens[index]);

                }
            }
        }
    }
}
