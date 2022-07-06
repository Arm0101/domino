using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Table
    {
        private List<IToken> history;
        private List<IFace> lastFaces;
        public List<IToken> History { get { return history; } }
        public List<IFace> LastFaces { private set { } get { return lastFaces; } }
        public Table() {
            history = new List<IToken>();
            lastFaces = new List<IFace>();
            
        }
        public void addToken(IToken token, IFace value)
        {
            List<IFace> list_faces = token.GetFaces().ToList();
            if (lastFaces.Count == 0)
            {
                history.Add(token);
                for (int i = 0; i < list_faces.Count; i++)
                {
                    lastFaces.Add(list_faces[i]);
                }
            }
            else
            {
                int aux = list_faces.Count(x => x.GetValue() == value.GetValue());
                if (aux == list_faces.Count)
                {
                    for (int i = 0; i < lastFaces.Count; i++)
                    {
                        if (value.GetValue() == lastFaces[i].GetValue())
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


                    if (value.GetValue() == lastFaces[i].GetValue())
                    {


                        lastFaces.RemoveAt(i);
                        for (int j = 0; j < token.GetFaces().ToList().Count; j++)
                        {
                            if (list_faces[j].GetValue() == value.GetValue()) continue;
                            lastFaces.Insert(i, list_faces[j]);


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
