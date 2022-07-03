using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
namespace ConsoleInterface
{
    public static class Print
    {
        public static void printToken(Token t)
        {
            Console.Write("[{0}:{1}]", t.Values[0], t.Values[1]);

        }
        public static void printTable(Table table)
        {
            Console.WriteLine();
            table.History.ForEach(x => printToken(x));
            Console.WriteLine();

            Console.WriteLine("->[{0}:{1}]", table.LastFaces[0], table.LastFaces[1]);

            Console.WriteLine();
        }
    }
}
