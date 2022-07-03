using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Table
    {
        private List<Token> history;
        private List<int> lastFaces;
        public List<int> LastFaces { private set { } get { return lastFaces; } }
        public Table() {
            history = new List<Token>();
            lastFaces = new List<int>();
            
        }
        public void addToken(Token token, int value)
        {
            history.Add(token);
            if (lastFaces.Count == 0)
            {
                for (int i = 0; i < token.Values.Count; i++)
                {
                    lastFaces.Add(token.Values[i]);
                }
            }
            else
            {
                for (int i = 0; i < lastFaces.Count; i++)
                {
                    if (value == lastFaces[i])
                    {
                        lastFaces.RemoveAt(i);
                        
                    }

                }
                for (int i = 0; i < token.Values.Count; i++)
                {
                    if (token.Values[i] == value) continue;
                    lastFaces.Add(token.Values[i]);
                }

            }


        }
    }
}
