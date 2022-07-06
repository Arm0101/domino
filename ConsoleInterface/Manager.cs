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
        private int getTurn(Player[] players) {
            if (actual_turn + 1 > order.Length - 1)
                actual_turn = -1;
            
             return order[++actual_turn];       
        }

        private bool finish(Table table, Player[] players) {
            foreach (var item in players)
            {
                if (item.tokens.Count == 0) return true;
            }
            foreach (var item in players) { 
                if (!item.isPassed()) return false;
            }
            return true;

        }
        private string Win(Table table, Player[] players )
        {
            string id = "";
            int points = int.MaxValue;
            foreach (var item in players)
            {


                if (item.tokens.Count == 0) return item.ID;
                int aux = 0;
                foreach (var t in item.tokens) {
                    aux += t.getValue();

                }
                if (aux < points) {
                    points = aux;
                    id = item.ID;
                }
            }
            return id;
            
           
        }
     


        
        
        public void play(Table table, Player[] players, Referee referee) {
            while (!finish(table,players))
            {
                int t = getTurn(players);
                IToken token;
                IFace val;
                (token,val ) = players[t].selectToken(table);
                if (token != null)
                {
                    table.addToken(token, val);
                }

                Console.Clear();
                Print.printTable(table);
                Console.WriteLine();
                if (players[t].isPassed())
                {
                    Console.WriteLine("El jugador {0} se ha pasado", players[t].ID);
                }
                else
                {
                    Console.WriteLine("El jugador {0} ha jugado", players[t].ID);
                    Print.printToken(token);

                }
                Thread.Sleep(1000);
            }

            Console.WriteLine("El jufador {0} ha ganado", Win(table,players));
        
        }
     
    }
}
