using Logic;

namespace Game
{
    public class NormalTable : ITable
    {
        private List<IFace> last_faces;
        private List<IToken> hist;
        public NormalTable() { 
            last_faces = new List<IFace>();
            hist = new List<IToken>();
        }
        public void addToken(IToken token, IFace value)
        {
            List<IFace> list_faces = token.GetFaces().ToList();
            if (last_faces.Count == 0)
            {
                hist.Add(token);
                for (int i = 0; i < list_faces.Count; i++)
                {
                    last_faces.Add(list_faces[i]);
                }
            }
            else
            {
                int aux = list_faces.Count(x => x.GetValue() == value.GetValue());
                if (aux == list_faces.Count)
                {
                    for (int i = 0; i < last_faces.Count; i++)
                    {
                        if (value.GetValue() == last_faces[i].GetValue())
                        {
                            if (i == 0) hist.Insert(0, token);
                            else
                            {
                                hist.Add(token);
                            }
                            return;
                        }
                    }


                }

                for (int i = 0; i < last_faces.Count; i++)
                {


                    if (value.GetValue() == last_faces[i].GetValue())
                    {


                        last_faces.RemoveAt(i);
                        for (int j = 0; j < token.GetFaces().ToList().Count; j++)
                        {
                            if (list_faces[j].GetValue() == value.GetValue()) continue;
                            last_faces.Insert(i, list_faces[j]);


                        }

                        if (i == 0) hist.Insert(0, token);
                        else
                        {
                            hist.Add(token);
                        }

                        return;

                    }

                }


            }
        }

        public IEnumerable<IFace> getCurrentFaces()
        {
            return last_faces;
        }

        public IEnumerable<IToken> getHistory()
        {
            return hist;
        }
    }
}
