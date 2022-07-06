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
        public static void printToken(IToken t)
        {
            IFace[] faces = t.GetFaces().ToArray();
            Console.Write("[{0}:{1}]", faces[0].getRepresentation(), faces[1].getRepresentation());

        }
        public static void printTable(Table table)
        {
            Console.WriteLine();
            table.History.ForEach(x => printToken(x));
            Console.WriteLine();

            Console.WriteLine("->[{0}:{1}]", table.LastFaces[0].GetValue(), table.LastFaces[1].GetValue());

            Console.WriteLine();
        }
    }
}
