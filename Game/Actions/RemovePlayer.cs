using Logic;

namespace Game
{
    public class RemovePlayer : IAction
    {
        public string Description() => "Un jugador es eliminado si se pasa";
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players, List<Token> toknes, History history)
        {


            string id = player.getID();
            bool check = false;
            for (int i = 0; i < history.IdHistory.Count; i++)
            {
                //recorrer el historial los jugadores
                if (history.IdHistory[i] != id) continue;
                //comprueba si se paso alguna vez
                if (history.TokensHistory[i] == null)
                {
                    check = true;
                    break;
                }
            }

            //si se paso se elimina el jugador
            if (check)
            {
                players.Remove(player);
                //agregar notificacion para mostrar en la interfaz
                Manager.Notify("El jugador " + player.getID() + " ha sido eliminado");

            }
        }
    }
}
