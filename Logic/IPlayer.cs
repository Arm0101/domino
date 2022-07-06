using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IPlayer
    {
        public (IToken, IFace) selectToken(ITable table, IValidator validator);
        public void addToken(IToken token);
        public IEnumerable<IToken> getTokens();
        public string getID();

    }
}
