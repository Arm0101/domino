using System;
using Logic;
namespace Logic
{
    public class Manager
    {

        private ITable table;
        private List<IPlayer> players;
        private IFinish finish;
        private History history;
        private IOrder order;
        private IWin win;
        IMonitor infoMonitor;
        static InfoHandler infoHandler;
        IEnumerable<IAction> actions;
        private List<Token> tokens;
        public Manager(ITable _table, ICollection<IPlayer> _players,IDistribute distribute, List<Token> _tokens,IOrder _order,
            IFinish _finish, IWin _win, IEnumerable<IAction> _actions, IMonitor _infoMonitor)
        {
            table = _table;
            players = _players.ToList();
            finish = _finish;
            
            distribute.HandOutTokens(players, _tokens);
            tokens = _tokens;
            order = _order;
            win = _win;
            infoMonitor = _infoMonitor;
            actions = _actions;
            infoHandler = new InfoHandler();
            history = new History();
        }

        public static void Notify(string noti) {
            infoHandler.Notify(noti);
        }
        public void play() {
            List<IPlayer> winners = new List<IPlayer> ();
            infoMonitor.Subscribe(infoHandler);
            while (!finish.Finish(table,players.ToArray(), history))
            {
                IPlayer player = order.GetPlayer(table,players.ToArray(), history);
                Token token;
                IFace val;
                (token,val) = player.selectToken(table,history);
                
                if (!table.Validate(player, token, history)) token = null;
                
                history.log(player.getID(), token);

                foreach(var action in actions)
                {
                    action.doSomething(player, token, val,table, players,tokens, history);
                }


                infoHandler.Update(table, history, players.ToList(), winners,false);
            }


            winners = win.getWiner(table, players, history).ToList();
            infoHandler.Update(table, history, players.ToList(), winners, true);
            infoMonitor.Unsubscribe();
        
        }
     
    }
}
