using Logic;

namespace Game
{
    public class NormalAction : IAction
    {
        public string Description() => "Se agrega la ficha a la mesa y se elimina de la mano del jugador";
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players,List<Token>  tokens,History history)
        {
            //si el jugador no se paso
            if (token != null)
            {
                //se agrega la ficha a la mesa
                table.addToken(token, face);
                //se elimina la ficha del jugador
                player.RemoveToken(token);
            }
        }
    }
}
