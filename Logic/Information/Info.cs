using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Info
    {
        private ITable table;
        private History history;
        private List<IPlayer> players_info;
        private string lastPlayerId;
        private Token lastToken;
        private List<IPlayer> winners;
        private bool finalized;
        private string notification;
        private bool change;

       
        //actualizar el estado del juego
        public void UpdateInfo(ITable _table, History _history, List<IPlayer> _players, List<IPlayer> _winners, bool _finalized) {
            table = _table;
            history = _history;
            players_info = _players;
            winners = _winners;
            finalized = _finalized;
            notification = "";
            setLastPlayerID();
            setLastToken();
            change = true;
        }
        //agregar notificacion
        public void addNotification(string not) {
            notification = not;
            change = false;
        }
        public ITable Table { get { return table; } }
        public History History { get { return history; } }
        public List<IPlayer> PlayersInfo { get { return players_info; } }

        public string Notification { get { return notification; } }
        public Token LastToken { get { return lastToken; } }

        public bool Finalized { get { return finalized; } }

        public List<IPlayer> Winners { get { return winners; } }

        public string LastPlayerId { get { return lastPlayerId; } }

        public bool Change { get { return change; } } 
        //establecer el jugador que hizo la ultima jugada
        private void setLastPlayerID()
        {
            if (history.IdHistory.Count > 0)
            lastPlayerId = history.IdHistory[history.IdHistory.Count - 1];
        }
        //establcer la ultima ficha que se jugo
        private void setLastToken() { 
            if  (history.TokensHistory.Count > 0)
            lastToken = history.TokensHistory[history.TokensHistory.Count - 1];
        }
    }
}
