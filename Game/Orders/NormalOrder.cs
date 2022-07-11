using Logic;

namespace Game
{
    public class NormalOrder : IOrder
    {
        
        private int actual_turn = -1;
        private int n_players; 
        public NormalOrder(IPlayer[] players) {
            
            n_players = players.Length;
        }
        public IPlayer GetPlayer(ITable table, IPlayer[] players, History history)
        {
            int dif = n_players - players.Length;
            actual_turn -= dif;
            if (actual_turn + 1 > players.Length - 1)
                actual_turn = -1;

            return players[++actual_turn];
        
    }
    }
}
