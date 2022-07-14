using Logic;
using Game;
namespace ConsoleInterface
{


    public class Program
    {   
        static void Main(string[] args) {
            
            ICollection<IPlayer> players = null;
            ITable table = null;
            IDistribute distribute = null;
            IOrder order = null;
            List<Token> tokens = null;
            IFinish finish = null;
            IWin win = null;
            IEnumerable<IAction> actions = null;
            IMonitor monitor = new InfoMonitor();


            GameSettings.SetOptions(out table, out players,out distribute, out order, out tokens, out finish,out win, out actions);

            Manager manager = GameSettings.BuildGame(table, players, distribute, order, tokens, finish, win, actions, monitor);
            manager.play();



        }
        
    }
  
    
}