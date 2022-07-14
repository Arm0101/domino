using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public interface IGenerator
    {
        public string Description();
        public IEnumerable<Token> generateTokens(int n);
    }
    
}
