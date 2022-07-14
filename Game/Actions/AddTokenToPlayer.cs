using Logic;

namespace Game
{
    public class AddTokenToPlayer : IAction
    {
        public string Description() => "Se le agrega una ficha al jugador si se pasa"; 
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players, List<Token> tokens, History history)
        {

            
            if (isPast(player, history) && tokens.Count > 0)
            {
                Random r = new Random();
                int index = r.Next(tokens.Count);
                player.addToken(tokens[index]);
                tokens.RemoveAt(index);
                Manager.Notify("Al jugador " + player.getID() + " se le ha agrgado una ficha ");
            }

            
        }

        private bool isPast(IPlayer player, History history) {
            for (int i = history.TokensHistory.Count - 1 ; i >= 0; i--) 
            {
                if (!history.IdHistory[i].Equals(player.getID())) continue;
                if (history.TokensHistory[i] == null) return true;
                return false;
            } 
           return false;
        }
    }
}
