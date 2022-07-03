using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Token
    {
        private List<int> values;
        public List<int> Values { get { return values; } }
        public Token() { 
           values = new List<int>();
        }
        public void setValues(List<int> values) {
            this.values = values;
        }
        public int getValue() {
            int val = 0;
            for (int i = 0; i < values.Count; i++)
            {
                val += values[i];
            }
            return val;
            
        }
 
    }
}
