using Logic;

namespace Game
{
    public class WinByPasses : IWin
    {
        public string Description() => "Gana el juagdor con menos pases";
        public IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> players, History history)
        {
            List<IPlayer> winners = new List<IPlayer>();
            int min_passes = int.MaxValue; //menor cantidad de pases
            foreach (IPlayer player in players)
            {
                //contar la cantidad de pases del jugador actual
                int currentCount = CountPasses(player, history);

                //si es igual a la de los ganadores actuales se agrega como ganador
                if (currentCount == min_passes) winners.Add(player);

                //tiene menor cantidad de pases entonces pasa a ser el ganador
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
            //Se busca en el historial de jugadas y contamos la cantidad de fichas null que correspondan al jugador
            for (int i = 0; i < history.IdHistory.Count; i++)
            {
                if (!history.IdHistory[i].Equals(player.getID())) continue;
                if (history.TokensHistory[i] == null) count++;
                
            }
            return count;
        }
    }
}
