using Logic;

namespace Game
{
    public class ReverseOrder : IOrder
    {

        public string Description() => "Se cambia el orden cada vez que un jugador se pasa";
        private int actual_turn; //indice del ultimo jugador
        private bool increment;
        private int n_players;
        public ReverseOrder(IEnumerable<IPlayer> players)
        {
            actual_turn = -1;
            n_players = players.ToArray().Length;
            increment = true;
        }

        public IPlayer GetPlayer(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();

            //verifico si el ultimo jugador se paso

            int index = history.TokensHistory.Count - 1;
            bool currentPast = false;
            string currentId = "";
            if (index >= 0)
            {
                currentId = history.IdHistory[index];
                currentPast = history.TokensHistory[index] == null;
                if (currentPast) increment = !increment; //si el ultimo jugador se paso se cambia el orden

            }
            //si se elimina algun jugador se actualiza la cantidad de jugadores y el indice del ultimo jugador
            int dif = n_players - players.Length;
            n_players -= dif;
            actual_turn -= dif;
            do
            {
                if (increment)
                {
                    actual_turn++; //indice para el jugador siguiente
                    if (actual_turn >= players.Length)
                        actual_turn = 0;
                }
                else
                {
                    actual_turn--;//indice para el jugador anterior
                    if (actual_turn < 0)
                        actual_turn = players.Length - 1;

                }
                //se repite el proceso si el jugador siguiente o anterior esta pasado y el jugador actual esta pasado
                //si se llega el jugador actual se rompe el ciclo
            } while (isPast(history, players[actual_turn]) && currentPast && players[actual_turn].getID() != currentId);

            return players[actual_turn];
        }

        public bool isPast(History history, IPlayer player)
        {
            int n = history.IdHistory.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                //comprobar las ultima ficha de un jugador
                if (!player.getID().Equals(history.IdHistory[i])) continue;
                if (history.TokensHistory[i] != null) return false;
                //si la ficha es null el jugador se paso
                if (object.Equals(history.TokensHistory[i], null)) return true;
            }
            return false;
        }
    }
}
