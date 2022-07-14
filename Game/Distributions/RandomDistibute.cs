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
            IPlayer[] _players = players.ToArray(); 
            Random random = new Random();
            for (int i = 0; i < _players.Length; i++) // recorrer los jugadores
            {
                for (int j = 0; j < n_players; j++) // agregar n fichas
                {
                    //se obtiene una ficha aleatoria y se le agrega al jugador i
                    int index = random.Next(0, tokens.Count); 
                    _players[i].addToken(tokens[index]);
                    tokens.Remove(tokens[index]);

                }
            }
        }
    }
}
