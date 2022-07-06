using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;
namespace ConsoleInterface
{
    public class Manager
    {
        private int[] order = {0,1,2,3 };
        private int actual_turn = -1;
        private int getTurn(IPlayer[] players) {
            if (actual_turn + 1 > order.Length - 1)
                actual_turn = -1;
            
             return order[++actual_turn];       
        }

        private bool finish(Table table, IPlayer[] players) {
            foreach (var item in players)
            {
                if (item.getTokens().ToList().Count == 0) return true;
            }
           
            return false;

        }
        private string Win(Table table, IPlayer[] players )
        {
            string id = "";
            int points = int.MaxValue;
            foreach (var item in players)
            {


                if (item.getTokens().ToList().Count == 0) return item.getID();
                int aux = 0;
                foreach (var t in item.getTokens().ToList()) {
                    aux += getValue(t);

                }
                if (aux < points) {
                    points = aux;
                    id = item.getID();
                }
            }
            return id;
            
           
        }
        public int getValue(IToken token)
        {
            int val = 0;
            foreach (var face in token.GetFaces())
            {
                val += face.GetValue();
            }
            return val;
        }




        public void play(Table table, IPlayer[] players, IValidator validator) {
            while (!finish(table,players))
            {
                int t = getTurn(players);
                IToken token;
                IFace val;
                (token,val ) = players[t].selectToken(table, validator);
                if (token != null)
                {
                    table.addToken(token, val);
                }

                Console.Clear();
                Print.printTable(table);
                Console.WriteLine();
                if (token == null)
                {
                    Console.WriteLine("El jugador {0} se ha pasado", players[t].getID());
                }
                else
                {
                    Console.WriteLine("El jugador {0} ha jugado", players[t].getID());
                    Print.printToken(token);

                }
                Console.ReadKey();
            }

            Console.WriteLine("El jufador {0} ha ganado", Win(table,players));
        
        }
     
    }
}
