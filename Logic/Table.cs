using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Table
    {
        private List<Token<int>> history;
        private List<int> currentValues;
        public void addToken(Token<int> token, int value) {
            history.Add(token);
            if (currentValues.Count == 0)
            {
                for (int i = 0; i < token.Values.Count; i++)
                {
                    currentValues.Add(token.Values[i]);
                }
            }
            else { 
                
                
            }
            
        
        }
        //public List<int> getLastValues { }
    }
}
