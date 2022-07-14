using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    //define quien es el jugador siguiente
    public interface IOrder
    {
        public string Description();
        public IPlayer GetPlayer(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
