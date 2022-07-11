using Logic;

namespace Game
{
    public class NormalFinish : IFinish
    {

        public bool Finish(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
           
            foreach (var item in players)
            {
                if (item.getTokens().ToList().Count == 0) return true;
            }
           
            if (history.TokensHistory.Count >= players.Length) {
               List <string> visited = new List <string>();
                
                for (int i = history.TokensHistory.Count - 1; i >= 0; i--) {
                    string id = history.IdHistory[i];
                    if (visited.Contains(id)) continue;
                    visited.Add(id);
                   
                    if (history.TokensHistory[i] != null) return false;
                    if (visited.Count == players.Length) return true;

                 }
            }

            return false;
        }
    }
}
