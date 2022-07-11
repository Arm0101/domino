using Logic;
using System.Threading;

namespace Game
{
    public class RemovePlayer : IAction
    {
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players,List<Token> toknes, History history)
        {
            string id = player.getID();
            bool check = false;
            for (int i = 0; i < history.IdHistory.Count; i++)
            {
                if (history.IdHistory[i] != id) continue;
                if (history.TokensHistory[i] == null) { 
                    check = true;
                    break;
                }
            }
            
            if (check) {
                 players.Remove(player);
                Manager.Notify("El jugador " + player.getID() + " ha sido eliminado");
                
            }
        }
    }
}
