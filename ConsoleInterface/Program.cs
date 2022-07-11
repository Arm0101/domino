using Logic;
using Game;
using Game.Actions;
using Game.Orders;
using Game.WinConditions;
namespace ConsoleInterface
{


    public class Program
    {
      
        static void Main(string[] args) {
            List<Token> tokens = TokensGenerator.generateTokens(9).ToList();
        
            IPlayer[] players = new IPlayer[4];
            players[0] = new NormalPlayer("01");
            players[1] = new NormalPlayer("02");
            players[2] = new NormalPlayer("03");
            players[3] = new NormalPlayer("04");
            Actions a = new Actions();
            IAction[] actions = { a };

            InfoMonitor infoMonitor = new InfoMonitor();
            Manager manager = new Manager(new NormalTable(),players, new ParImparDistribute(10) , tokens, new NormalOrder(players),new FinalizedByPasses(),new NormalWin(), actions ,new History(), infoMonitor);
            manager.play();
            

           
        }
        
    }
  
    
}