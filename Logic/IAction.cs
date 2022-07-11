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
        public void doSomething(IPlayer player, Token token, IFace face, ITable table, IPlayer[] players, History history);
    }
}
