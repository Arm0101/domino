using System;
using Logic;
namespace ConsoleInterface {

    public class Program
    {

       
        static int count = 0;
        static void Main(string[] args) {
            List<Token> tokens = TokensGenerator.generateTokens(9);
            Table table = new Table();
            Referee referee = new Referee();
            Player[] players = new Player[4];
            players[0] = new Player("01");
            players[1] = new Player("02");
            players[2] = new Player("03");
            players[3] = new Player("04");
            referee.handOutTokens(tokens, players);
            players[0].tokens.ForEach(x => Console.WriteLine("[{0}:{1}]", x.Values[0], x.Values[1]));

            //tokens.ForEach(x => { Console.WriteLine("{0}-{1}",x.Values[0], x.Values[1]); });
            table.addToken(tokens[0], 1);
            table.LastFaces.ForEach(x => { Console.Write("{0} ", x); } );
            Console.WriteLine();
            table.addToken(tokens[1], 1);
            table.LastFaces.ForEach(x => { Console.Write("{0} ", x); });
            Console.WriteLine();
            Token t;
            int val;
            (t, val) = players[0].selectToken(table);
            players[0].tokens.ForEach(x => Console.WriteLine("[{0}:{1}]", x.Values[0], x.Values[1]));
            //referee.handOutTokens(tokens, 4);





        }
        
    }
  
    
}