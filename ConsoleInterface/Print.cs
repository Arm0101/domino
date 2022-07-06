﻿using System;
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
        public static void printTable(ITable table)
        {
            Console.WriteLine();
            List <IFace> last_faces = table.getCurrentFaces().ToList();
            table.getHistory().ToList().ForEach(x => printToken(x));
            Console.WriteLine();

            Console.WriteLine("->[{0}:{1}]", last_faces[0].getRepresentation(), last_faces[1].getRepresentation());

            Console.WriteLine();
        }
    }
}
