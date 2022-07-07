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
            /*if (!tokens[0].Face1.Equals(table.FaceLeft()))
            {
                IFace f1, f2;
                f1 = tokens[0].Face2;
                f2 = tokens[0].Face1;
                tokens[0] = new Token(f1, f2);

            }
            printToken(tokens[0]);


            for (int i = 1; i < tokens.Count; i++)
            { 
                if (!tokens[i].Face1.Equals(tokens[i - 1].Face2))
                    tokens[i] = new Token(tokens[i].Face2, tokens[i].Face1);
                printToken(tokens[i]);
            }
        */


            Console.WriteLine();

            tokens.ForEach(t => printToken(t));
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
