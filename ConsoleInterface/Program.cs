using System;
using Logic;
using Game;
namespace ConsoleInterface {

 
    public class Program
    {
      
        static void Main(string[] args) {
            List<IToken> tokens = TokensGenerator.generateTokens(9).ToList();
        
            IPlayer[] players = new IPlayer[4];
            players[0] = new NormalPlayer("01");
            players[1] = new NormalPlayer("02");
            players[2] = new NormalPlayer("03");
            players[3] = new NormalPlayer("04");
          


            Manager manager = new Manager(new Table(),players, new RandomDistibute(10) , tokens,new NormalFinish(), new NormalValidator(), new History());
            manager.play();
           
            //IToken t;
            //IFace f;
            //(t, f) = players[0].selectToken(table, new NormalValidator());
            //table.addToken(t,f);
            //Print.printTable(table);
            /*players[0].getTokens().ToList().ForEach(x => {
                Print.printToken(x);
                Console.WriteLine();
                
                });
           */
         
        }
        
    }
  
    
}