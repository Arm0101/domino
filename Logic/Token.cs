using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Token<T>
    {
        private List<T> values;
        public List<T> Values { get { return values; } }
        public Token() { 
           values = new List<T>();
        }
        public void setValues(List<T> values) {
            this.values = values;
        }
 
    }
}
