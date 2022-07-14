using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{

    //define que acciones realizar despues que el jugador realice una jugada
    public interface IAction
    {
        public string Description();
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, ICollection<IPlayer> players,List<Token> tokens, History history);
    }
}
