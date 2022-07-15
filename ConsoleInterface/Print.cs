using Logic;
namespace ConsoleInterface
{
    public static class Print
    {

        //se imprime una ficha de la forma [1:2]
        public static void printToken(Token t)
        {
            Console.Write("[{0}:{1}]", t.Face1.getRepresentation(), t.Face2.getRepresentation());

        }
        //se imprimen las fichas jugadas y las caras por donde se puede jugar
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
        //se muestran las fichas de los jugadores
        public static void printPlayersTokens(IEnumerable<IPlayer> players)
        {
            int n = 0;

            players.ToList().ForEach(x => { if (x.getTokens().ToList().Count > n) n = x.getTokens().ToList().Count; });
            Console.WriteLine();
            for (int i = 0; i < n; i++)
            {

                foreach (var player in players)
                {
                    Token[] tokens = player.getTokens().ToArray();
                    if (tokens.Length - 1 >= i)
                    {
                        printToken(tokens[i]);
                    }
                    else
                    {
                        Console.Write("[-:-]");
                    }
                    Console.Write("      ");

                }
                Console.WriteLine();
            }

        }
    }
}
