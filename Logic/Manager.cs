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
        IAction[] actions;
        public Manager(ITable _table, IPlayer[] _players,IDistribute distribute, List<Token> tokens,IOrder _order,
            IFinish _finish, IWin _win, IAction[] _actions,History _history, IMonitor _infoMonitor)
        {
            table = _table;
            players = _players;
            finish = _finish;
            history = _history;
            distribute.HandOutTokens(players, tokens);
            order = _order;
            win = _win;
            infoMonitor = _infoMonitor;
            actions = _actions;
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
                
                if (!table.Validate(player, token, history)) token = null;
                
                history.log(player.getID(), token);

                foreach(var action in actions)
                {
                    action.doSomething(player, token, val,table, players, history);
                }


                infoHandler.Update(table, history, players.ToList(), winners,false);
            }


            winners = win.getWiner(table, players, history).ToList();
            infoHandler.Update(table, history, players.ToList(), winners, true);
            infoMonitor.Unsubscribe();
        
        }
     
    }
}
