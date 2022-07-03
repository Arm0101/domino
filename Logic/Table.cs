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
        public List<Token> History { get { return history; } }
        public List<int> LastFaces { private set { } get { return lastFaces; } }
        public Table() {
            history = new List<Token>();
            lastFaces = new List<int>();
            
        }
        public void addToken(Token token, int value)
        {
            
            if (lastFaces.Count == 0)
            {
                history.Add(token);
                for (int i = 0; i < token.Values.Count; i++)
                {
                    lastFaces.Add(token.Values[i]);
                }
            }
            else
            {
                int aux = token.Values.Count(x => x == value);
                if (aux == token.Values.Count)
                {
                    for (int i = 0; i < lastFaces.Count; i++)
                    {
                        if (value == lastFaces[i])
                        {
                            if (i == 0) history.Insert(0, token);
                            else
                            {
                                history.Add(token);
                            }
                            return;
                        }
                    }
                  

                }
               
                for (int i = 0; i < lastFaces.Count; i++)
                {


                    if (value == lastFaces[i])
                    {


                        lastFaces.RemoveAt(i);
                        for (int j = 0; j < token.Values.Count; j++)
                        {
                            if (token.Values[j] == value) continue;
                            lastFaces.Insert(i, token.Values[j]);


                        }

                        if (i == 0) history.Insert(0, token);
                        else
                        {
                            history.Add(token);
                        }

                        return;
                       
                    }

                }
              

            }


        }

    }
}
