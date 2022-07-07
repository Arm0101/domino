using System;
using Logic;
using Game;
namespace ConsoleInterface {

 
    public class Program
    {
      
        static void Main(string[] args) {
            List<Token> tokens = TokensGenerator.generateTokens(9).ToList();
        
            IPlayer[] players = new IPlayer[4];
            players[0] = new NormalPlayer("01");
            players[1] = new NormalPlayer("02");
            players[2] = new NormalPlayer("03");
            players[3] = new NormalPlayer("04");


            InfoMonitor infoMonitor = new InfoMonitor();
            Manager manager = new Manager(new NormalTable(),players, new RandomDistibute(10) , tokens, new NormalOrder(players),new NormalFinish(),new NormalWin(), new NormalValidator(), new History(), infoMonitor);
            manager.play();
            

           
        }
        
    }
  
    
}