using Logic;

namespace Game.WinConditions
{
    public class NormalWin : IWin
    {
        public IEnumerable<IPlayer> getWiner(ITable table, IPlayer[] players, History history)
        {
            IPlayer[] winner = new IPlayer[1];
            int points = int.MaxValue;
            foreach (var item in players)
            {


                if (item.getTokens().ToList().Count == 0) return new IPlayer[] { item };
                int aux = 0;


                foreach (var t in item.getTokens().ToList())
                {
                    aux += getValue(t);

                }
                if (aux < points)
                {
                    points = aux;
                    winner[0] = item;
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
