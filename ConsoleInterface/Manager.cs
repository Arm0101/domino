﻿using System;
using Logic;
namespace ConsoleInterface
{
    public class Manager
    {

        private Table table;
        private IPlayer[] players;
        private IFinish finish;
        private History history;
        private IValidator validator;
        public Manager(Table _table, IPlayer[] _players,IDistribute distribute, List<IToken> tokens, IFinish _finish, IValidator _validator ,History _history)
        {
            table = _table;
            players = _players;
            finish = _finish;
            history = _history;
            distribute.HandOutTokens(players, tokens);
            validator = _validator;
        }
        private int[] order = {0,1,2,3 };
        private int actual_turn = -1;
        private int getTurn(IPlayer[] players) {
            if (actual_turn + 1 > order.Length - 1)
                actual_turn = -1;
            
             return order[++actual_turn];       
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




        public void play() {
            while (!finish.Finish(table,players, history))
            {
                int t = getTurn(players);
                IToken token;
                IFace val;
                (token,val ) = players[t].selectToken(table, validator);
                if (token != null)
                {
                    table.addToken(token, val);
                }
                history.log(players[t].getID(), token);
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
