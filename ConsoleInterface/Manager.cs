using System;
using Logic;
namespace ConsoleInterface
{
    public class Manager
    {

        private ITable table;
        private IPlayer[] players;
        private IFinish finish;
        private History history;
        private IValidator validator;
        private IOrder order;
        private IWin win;
        public Manager(ITable _table, IPlayer[] _players,IDistribute distribute, List<Token> tokens,IOrder _order, IFinish _finish, IWin _win ,IValidator _validator ,History _history)
        {
            table = _table;
            players = _players;
            finish = _finish;
            history = _history;
            distribute.HandOutTokens(players, tokens);
            validator = _validator;
            order = _order;
            win = _win;
        }
      
   
        public void play() {
            while (!finish.Finish(table,players, history))
            {
                IPlayer player = order.GetPlayer(table,players, history);
                Token token;
                IFace val;
                (token,val ) = player.selectToken(table, validator);
                if (token != null)
                {
                    table.addToken(token, val);
                }
                history.log(player.getID(), token);
                Console.Clear();
                Print.printTable(table);
                Console.WriteLine();
                if (token == null)
                {
                    Console.WriteLine("El jugador {0} se ha pasado", player.getID());
                }
                else
                {
                    Console.WriteLine("El jugador {0} ha jugado", player.getID());
                    Print.printToken(token);

                }

                Print.printPlayersTokens(players);
                Console.ReadKey();
            }
           
            foreach (IPlayer player in win.getWiner(table,players,history)) {
                Console.WriteLine("El jugador {0} ha ganado", player.getID());
            }
        
        }
     
    }
}
