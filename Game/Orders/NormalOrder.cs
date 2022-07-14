using Logic;

namespace Game
{
    public class NormalOrder : IOrder
    {
        public string Description() => "Orden clasico";
        private int actual_turn = -1; //el indicie del ultimo jugador
        private int n_players; 
        public NormalOrder(IEnumerable<IPlayer> players) {
            
            n_players = players.ToArray().Length;
        }
        public IPlayer GetPlayer(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
            int dif = n_players - players.Length;
            n_players -= dif; //por si se elimina algun jugador
            actual_turn -= dif; //en caso de que se elimina algun jugador el indice del ultimo jugador cambia
            if (actual_turn + 1 == players.Length) //si se llega al ultimo, vuelve a empezar 
                actual_turn = -1;

             return players[++actual_turn]; //devuelve el jugador en la posicion siguiente
        
    }
    }
}
