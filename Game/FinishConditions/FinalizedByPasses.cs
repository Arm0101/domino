using Logic;

namespace Game
{
    public class FinalizedByPasses : IFinish
    {
        public bool Finish(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
            
            foreach (var player in players)
            {
                int count = 0;
                string id = player.getID();
                for (int i = 0; i < history.IdHistory.Count; i++)
                {
                    if (!history.IdHistory[i].Equals(id)) continue;
                    if (history.TokensHistory[i] == null) count++;
                    if (count == 2) return true;
                }
            }
            return false; 
        }
    }
}
