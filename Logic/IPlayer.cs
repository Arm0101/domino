using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IPlayer
    {
        public (Token, IFace) selectToken(ITable table, History history);
        public void addToken(Token token);
        public IEnumerable<Token> getTokens();
        public string getID();

    }
}
