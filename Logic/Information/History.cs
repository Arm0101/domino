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
        private List<Token> tokens;
       
        public History() { 
            id_player = new List<string>();
            tokens = new List<Token>();
        }
       
        public List<string> IdHistory { get{ return id_player; } set { } }
        public List<Token> TokensHistory { set { } get { return tokens; } }
        public void log(string id, Token token)
        {
            id_player.Add(id);
            tokens.Add(token);

        }

    }
}
