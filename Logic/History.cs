using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class History
    {
        private List<string> id_player;
        private List<IToken> tokens;
        public History() { 
            id_player = new List<string>();
            tokens = new List<IToken>();
        }
        public List<string> IdHistory { get{ return id_player; } set { } }
        public List<IToken> TokensHistory { set { } get { return tokens; } }
        public void log(string id, IToken token)
        {
            id_player.Add(id);
            tokens.Add(token);
        }

    }
}
