using Logic;

namespace Game
{
    public class NormalAction : IAction
    {
        public string Description() => "Se agrega la ficha a la mesea y se elimina de la mano del jugador";
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players,List<Token>  tokens,History history)
        {
            if (token != null)
            {
                table.addToken(token, face);
                player.RemoveToken(token);
            }
        }
    }
}
