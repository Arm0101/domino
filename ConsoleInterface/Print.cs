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
            List<Token> tokens = table.getHistory().ToList();
            
            tokens.ForEach(t => printToken(t));
            Console.WriteLine();
            string left = "";
            string right = "";
            if (table.FaceLeft() == null && table.FaceRight() == null)
            {
                left = right = "-";
            }
            else
            {
                left = table.FaceLeft().getRepresentation();
                right = table.FaceRight().getRepresentation();
            }
            Console.WriteLine("->[{0}:{1}]", left, right);

        }
        public static void printPlayersTokens(List<IPlayer> players) {
            int n = 0;
            
            players.ForEach(x => { if (x.getTokens().ToList().Count > n) n = x.getTokens().ToList().Count; });
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {
                
                for (int j = 0; j < players.Count; j++) {
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
