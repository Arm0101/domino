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

    

       
        public void UpdateInfo(ITable _table, History _history, List<IPlayer> _players, List<IPlayer> _winners, bool _finalized) {
            table = _table;
            history = _history;
            players_info = _players;
            winners = _winners;
            finalized = _finalized;

            setLastPlayerID();
            setLastToken();
        }

        public ITable Table { get { return table; } }
        public History History { get { return history; } }
        public List<IPlayer> PlayersInfo { get { return players_info; } }

        public Token LastToken { get { return lastToken; } }

        public bool Finalized { get { return finalized; } }

        public List<IPlayer> Winners { get { return winners; } }

        public string LastPlayerId { get { return lastPlayerId; } }


        private void setLastPlayerID()
        {
            lastPlayerId = history.IdHistory[history.IdHistory.Count - 1];
        }
        private void setLastToken() { 
            lastToken = history.TokensHistory[history.TokensHistory.Count - 1];
        }
    }
}
