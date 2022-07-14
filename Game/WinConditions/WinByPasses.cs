using Logic;

namespace Game
{
    public class WinByPasses : IWin
    {
        public string Description() => "Gana el juagdor con menos pases";
        public IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> players, History history)
        {
            List<IPlayer> winners = new List<IPlayer>();
            int min_passes = int.MaxValue;
            foreach (IPlayer player in players)
            {
                int currentCount = CountPasses(player, history);
                if (currentCount == min_passes) winners.Add(player);
                if (currentCount < min_passes) {
                    winners.Clear();
                    winners.Add(player);
                    min_passes = currentCount;
                }
            }
            return winners;
        }
        private int CountPasses(IPlayer player, History history) {
            int count = 0;
            for (int i = 0; i < history.IdHistory.Count; i++)
            {
                if (!history.IdHistory[i].Equals(player.getID())) continue;
                if (history.TokensHistory[i] == null) count++;
                
            }
            return count;
        }
    }
}
