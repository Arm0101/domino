using Logic;

namespace Game
{
    public class NormalOrder : IOrder
    {
        private int[] order;
        private int actual_turn = -1;
        public NormalOrder(IPlayer[] players) {
            order = new int[players.Length];
            for (int i = 0; i < players.Length; i++)
            {
                order[i]= i;
            }
        
        }
        public IPlayer GetPlayer(Table table, IPlayer[] players, History history)
        {
       
            if (actual_turn + 1 > order.Length - 1)
                actual_turn = -1;

            return players[order[++actual_turn]];
        
    }
    }
}
