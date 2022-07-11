using Logic;

namespace Game
{
    public class NormalOrder : IOrder
    {
        
        private int actual_turn = -1;
        private int n_players; 
        public NormalOrder(IEnumerable<IPlayer> players) {
            
            n_players = players.ToArray().Length;
        }
        public IPlayer GetPlayer(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
            int dif = n_players - players.Length;
            n_players -= dif;
            actual_turn -= dif;
            if (actual_turn + 1 == players.Length)
                actual_turn = -1;

             return players[++actual_turn];
        
    }
    }
}
