using Logic;

namespace Game
{
    public class NormalWin : IWin
    {
        public string Description() => "Gana el que con menos puntos";
        public IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
            List<IPlayer> winner = new List<IPlayer>();
            int points = int.MaxValue;
            foreach (var item in players)
            {


                if (item.getTokens().ToList().Count == 0) return new IPlayer[] { item };
                int aux = 0;


                foreach (var t in item.getTokens().ToList())
                {
                    aux += getValue(t);

                }
                if (aux == points)
                {
                    
                    winner.Add(item);
                }
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
