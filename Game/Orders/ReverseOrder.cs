using Logic;

namespace Game.Orders
{
    public class ReverseOrder:IOrder
    {

        private int actual_turn;
        private bool increment;
        private int n_players;
        public ReverseOrder(IPlayer[] players)
        {
            actual_turn = -1;
            n_players = players.Length;
            increment = true;
        }

        public IPlayer GetPlayer(ITable table, IPlayer[] players, History history)
        {
            //verifico si el ultimo jugador se paso
            
            int index = history.TokensHistory.Count - 1;
            bool currentPast = false;
            string currentId = "";
            if (index >= 0)
            {
                currentId = history.IdHistory[index];
                currentPast =  history.TokensHistory[index] == null;
                if (currentPast) increment = !increment;

            }
            int dif = n_players - players.Length;
            actual_turn -= dif;
            do
            {
                if (increment)
                {
                    actual_turn++;
                    if (actual_turn  >= players.Length)
                        actual_turn = 0;
                }
                else
                {
                    actual_turn--;
                    if (actual_turn < 0)
                        actual_turn = players.Length - 1; 

                }
            } while (isPast(history,players[actual_turn])  && currentPast && players[actual_turn].getID() != currentId);

            return players[actual_turn];
        }

        public bool isPast(History history , IPlayer player) {
            int n = history.IdHistory.Count;
            for (int i = n - 1; i >= 0; i--)
            {
                if (!player.getID().Equals(history.IdHistory[i])) continue;
                if (object.Equals(history.TokensHistory[i], null)) return true;
            }
            return false;
        }
    }
}
