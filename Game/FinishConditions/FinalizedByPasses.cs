using Logic;

namespace Game
{
    public class FinalizedByPasses : IFinish
    {
        public string Description() => "El juego finaliza si un juagdor llega a los 2 pases";
        public bool Finish(ITable table, IEnumerable<IPlayer> p, History history)
        {
            //recorrer jugadores
            foreach (var player in p)
            {
                int count = 0;
                string id = player.getID();
                for (int i = 0; i < history.IdHistory.Count; i++)
                {
                    //si no es el jugador actual continua
                    if (!history.IdHistory[i].Equals(id)) continue;

                    //contar cantidad de veces que se paso el jugador
                    if (history.TokensHistory[i] == null) count++;
                    // si se encuentra un jugador que se paso 2 veces se finaliza el juego
                    if (count == 2) return true;
                }
            }
            return false;
        }
    }
}
