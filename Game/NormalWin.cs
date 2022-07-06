using Logic;

namespace Game
{
    public class NormalWin : IWin
    {
        public IPlayer[] getWiner(Table table, IPlayer[] players, History history)
        {
            IPlayer[] winner = new IPlayer[1];
            int points = int.MaxValue;
            foreach (var item in players)
            {


                if (item.getTokens().ToList().Count == 0) return new IPlayer[] {item};
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

        private int getValue(IToken token)
        {
            int val = 0;
            foreach (var face in token.GetFaces())
            {
                val += face.GetValue();
            }
            return val;
        }

    }
}
