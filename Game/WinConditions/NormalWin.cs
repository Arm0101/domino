using Logic;

namespace Game
{
    public class NormalWin : IWin
    {
        public string Description() => "Gana el jugador con menos puntos";
        public IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
            List<IPlayer> winner = new List<IPlayer>();
            int points = int.MaxValue; //menor cantidad de puntos
            foreach (var item in players)
            {

                //si un jugador se queda sin fichas gana
                if (item.getTokens().ToList().Count == 0) return new IPlayer[] { item };
                int aux = 0;

                //se calcula el total de puntos de un jugador
                foreach (var t in item.getTokens().ToList())
                {
                    aux += getValue(t);

                }
                //si es igual al mejor actual se agrega como ganador
                if (aux == points)
                {

                    winner.Add(item);
                }
                //si el jugador tiene menos puntos que los ganadores actuales pasa a ser el ganador
                if (aux < points)
                {
                    points = aux;
                    winner.Clear();
                    winner.Add(item);
                }
            }
            return winner;

        }

        private int getValue(Token token)
        {
            int val = 0;
            val += token.Face1.GetValue();
            val += token.Face2.GetValue();
            return val;
        }

    }
}
