using Logic;

namespace Game
{
    public class AddTokenToPlayer : IAction
    {
        public string Description() => "Se le agrega una ficha al jugador si se pasa"; 
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players, List<Token> tokens, History history)
        {

            // si el jugador se paso
            if (isPast(player, history) && tokens.Count > 0)
            {
                //se le agrega una ficha aleatoria de las que sobraron despues que se repartieron
                Random r = new Random();
                int index = r.Next(tokens.Count);
                player.addToken(tokens[index]);
                tokens.RemoveAt(index);// se elimina esa ficha de las sobrantes
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
