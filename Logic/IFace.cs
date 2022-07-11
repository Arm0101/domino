using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IFace : IEquatable<IFace>
    {
        public int GetValue();
        public string getRepresentation();

        public IFace GetInstance();
    }
}
