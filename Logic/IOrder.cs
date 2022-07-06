using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IOrder
    {
       public IPlayer GetPlayer(Table table, IPlayer[] players, History history);
    }
}
