using Logic;

namespace Game.Actions
{
    public class Actions : IAction
    {
        public Actions()
        {
        }
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, IPlayer[] players, History history)
        {
            if (token != null)
            {
                table.addToken(token, face);
                player.RemoveToken(token);
            }
        }
    }
}
