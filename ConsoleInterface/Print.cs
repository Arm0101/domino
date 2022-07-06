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
        public static void invert (IToken token) {

        }
        public static void printTable(Table table)
        {
            Console.WriteLine();
            IToken[] tokens = table.History.ToArray();
            for (int i = 0; i < tokens.Length - 1; i++) { 
               
            }
            Console.WriteLine();

            Console.WriteLine("->[{0}:{1}]", table.LastFaces[0].getRepresentation(), table.LastFaces[1].getRepresentation());

            Console.WriteLine();
        }
    }
}
