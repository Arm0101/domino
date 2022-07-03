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

        public static void endl()
        {
            int l, t;
            (l, t) = Console.GetCursorPosition();
            Console.SetCursorPosition(0, t + 5);
          

        }
        /*public static void printToken(Token<int> token, bool endl = false, bool vertical = false) {
            if (vertical)
                printVerticalToken(token, endl);
            else
                printHorizontalToken(token, endl);

        }*/

      /*  private static void printVerticalToken(Token<int> token, bool endl = false)
        {
            int l, t;
            (l, t) = Console.GetCursorPosition();
            Console.Write(" --- ");
            Console.SetCursorPosition(l, t + 1);
            int _t = t, _l = l;
            for (int i = 0; i < token.Values.Count; i++)
            {

                Console.SetCursorPosition(_l, ++_t);
                Console.Write("| {0} |", token.Values[i]);
                Console.SetCursorPosition(l, ++_t);
                Console.Write(" --- ");


            }
            (l, t) = Console.GetCursorPosition();

            if (l + 10 > Console.BufferWidth)
            {
                Console.SetCursorPosition(0, t + 5);
            }
            else
            {
                if (endl)
                    Console.WriteLine();
                else
                    Console.SetCursorPosition(l + 1, t - 4);

            }

        }
        private static void printHorizontalToken(Token<int> token, bool endl = false)
        {
            int l, t;
            (l, t) = Console.GetCursorPosition();
            Console.Write(" ------- ");
            Console.SetCursorPosition(l, t + 1);
            Console.Write("|");

            for (int i = 0; i < token.Values.Count; i++)
            {

                Console.Write(" {0} |", token.Values[i]);


            }
            Console.SetCursorPosition(l, t + 2);
            Console.Write(" ------- ");
            Console.Write(" ");

            (l, t) = Console.GetCursorPosition();


            if (l + 10 > Console.BufferWidth)
            {
                Console.SetCursorPosition(0, t + 2);
            }
            else
            {
                if (endl)
                    Console.WriteLine();
                else
                    Console.SetCursorPosition(l, t - 2);

            }

        }*/
    }
}
