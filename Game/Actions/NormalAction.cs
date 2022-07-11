using Logic;

namespace Game
{
    public class NormalAction : IAction
    {
       
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
