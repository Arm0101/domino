using Logic;

namespace Game
{
    public class NormalFinish : IFinish
    {

        public bool Finish(Table table, IPlayer[] players, History history)
        {
            foreach (var item in players)
            {
                if (item.getTokens().ToList().Count == 0) return true;
            }
           
            if (history.TokensHistory.Count >= players.Length) {
                
                for (int i = history.TokensHistory.Count - players.Length; i < history.TokensHistory.Count; i++)
                {
                    if (history.TokensHistory[i] != null) return false;
                }
                return true;
            }

            return false;
        }
    }
}
