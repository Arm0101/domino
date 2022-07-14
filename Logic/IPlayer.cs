using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IPlayer
    {
        public string Description();
        public  (Token, IFace) selectToken(ITable table, History history);
        public void RemoveToken(Token token);
        public void addToken(Token token);
        public IEnumerable<Token> getTokens();
        public string getID();

    }
}
