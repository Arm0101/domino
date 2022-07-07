using System;
using Logic;
namespace ConsoleInterface
{
    public static class Print
    {
        public static void printToken(Token t)
        {
           Console.Write("[{0}:{1}]", t.Face1.getRepresentation(), t.Face2.getRepresentation());
        }
        public static void printTable(ITable table)
        {
            Console.WriteLine();
            table.getHistory().ToList().ForEach(x => printToken(x));
            Console.WriteLine();

            Console.WriteLine("->[{0}:{1}]", table.FaceLeft().getRepresentation(), table.FaceRight().getRepresentation());

            Console.WriteLine();
        }
        public static void printPlayersTokens(IPlayer[] players) {
            int n = 0;
            
            players.ToList().ForEach(x => { if (x.getTokens().ToList().Count > n) n = x.getTokens().ToList().Count; });
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                
                for (int j = 0; j < players.Length; j++) {
                    Token [] tokens = players[j].getTokens().ToArray();
                    if (tokens.Length - 1 >= i)
                    {
                        printToken(tokens[i]);
                    }
                    else {
                        Console.Write("[-:-]");
                    }
                    Console.Write("      ");
                   
                }
                Console.WriteLine();
            }
      
        }
    }
}
