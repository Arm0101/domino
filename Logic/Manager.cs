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
        private IOrder order;
        private IWin win;
        IMonitor infoMonitor;
        InfoHandler infoHandler;
        public Manager(ITable _table, IPlayer[] _players,IDistribute distribute, List<Token> tokens,IOrder _order,
            IFinish _finish, IWin _win ,History _history, IMonitor _infoMonitor)
        {
            table = _table;
            players = _players;
            finish = _finish;
            history = _history;
            distribute.HandOutTokens(players, tokens);
            order = _order;
            win = _win;
            infoMonitor = _infoMonitor;
            infoHandler = new InfoHandler();
        }
      
   
        public void play() {
            List<IPlayer> winners = new List<IPlayer> ();
            infoMonitor.Subscribe(infoHandler);
            while (!finish.Finish(table,players, history))
            {
                IPlayer player = order.GetPlayer(table,players, history);
                Token token;
                IFace val;
                (token,val) = player.selectToken(table,history);
                if (token != null)
                {
                    table.addToken(token, val);
                }
               
                
                history.log(player.getID(), token);
                infoHandler.Update(table, history, players.ToList(), winners,false);
            }


            winners = win.getWiner(table, players, history).ToList();
            infoHandler.Update(table, history, players.ToList(), winners, true);
            infoMonitor.Unsubscribe();
        
        }
     
    }
}
