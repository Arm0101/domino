using Logic;
using Game;

using Game.Orders;
using Game.WinConditions;
namespace ConsoleInterface
{


    public class Program
    {
      
        static void Main(string[] args) {
            List<Token> tokens = NumericTokensGenerator.generateTokens(9).ToList();
         

            IPlayer[] players = new IPlayer[4];
            players[0] = new AlmostSmartPlayer("01");
            players[1] = new AlmostSmartPlayer("02");
            players[2] = new NormalPlayer("03");
            players[3] = new NormalPlayer("04");
            NormalAction a = new NormalAction();
            RemovePlayer b = new RemovePlayer();
            AddTokenToPlayer c = new AddTokenToPlayer();
            IAction[] actions = { a, c};

            InfoMonitor infoMonitor = new InfoMonitor();
            Manager manager = new Manager(new NormalTable(),players, new RandomDistibute(10) , tokens, new NormalOrder(players),new NormalFinish(),new NormalWin(), actions ,new History(), infoMonitor);
            manager.play();
            

           
        }
        
    }
  
    
}