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

        //se establecen las instancias concretas que se utilizaran en el juego
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

        //enviar notificacion
        public static void Notify(string noti) {
            infoHandler.Notify(noti);
        }
        public void play() {
            List<IPlayer> winners = new List<IPlayer> ();
            infoMonitor.Subscribe(infoHandler); //infoMonitor sera el encargado de recibir las notificaciones 
            //y permitira mostrar los cambios en el juego

            //mientras el juego no haya finalizado
            while (!finish.Finish(table,players.ToArray(), history))
            {
                //devuelve el jugador al que le toca jugar
                IPlayer player = order.GetPlayer(table,players.ToArray(), history);
                Token token;
                IFace face;
                //se obtiene la ficha y la cara por donde el jugador decidio jugar
                (token,face) = player.selectToken(table,history);
                //se valida la ficha
                if (!table.Validate(player, token,face, history)) token = null;
                //se registra la jugada en el historial
                history.log(player.getID(), token);

                //se realizan las accciones definidas por el usuario
                foreach(var action in actions)
                {
                    action.doSomething(player, token, face,table, players,tokens, history);
                }

                //se informa que el estado del juego cambio
                infoHandler.Update(table, history, players.ToList(), winners,false);
            }

            //se obtienen los ganadores
            winners = win.getWiner(table, players, history).ToList();

            //se informa que el estado del juego cambio
            infoHandler.Update(table, history, players.ToList(), winners, true);

            //infoMonitor dejara de recibir informacion
            infoMonitor.Unsubscribe();
        
        }
     
    }
}
