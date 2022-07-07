using Logic;

namespace Game
{
    public class NormalTable : ITable
    {
        private IFace ? face1;
        private IFace ? face2;
        private List<Token> hist;
        public NormalTable() {
            hist = new List<Token>();
        }
        public void addToken(Token token, IFace value)
        {
            if (face1 == null && face2 == null)
            {
                face1 = token.Face1;
                face2 = token.Face2;
                hist.Add(token);
                return;
            }
            if (token.Face1.Equals(token.Face2))
            {
                if (value.Equals(face2))
                {
                    hist.Add(token);
                    return;
                }
                else
                {
                    hist.Insert(0, token);
                    return;
                }
            }
            if (value.Equals(token.Face1))
            {
                if (face1.Equals(value))
                {
                    face1 = token.Face2;
                    hist.Insert(0, token);
                    return ;
                }
                if (face2.Equals(value))
                {
            
                    face2 = token.Face2;
                    hist.Add(token);
                    return;
                }
            }
            if (value.Equals(token.Face2))
            {
                if (face1.Equals(value))
                {
                    face1 = token.Face1;
                    hist.Insert(0, token);
                    return;
                }
                if (face2.Equals(value))
                {
                    face2 = token.Face1;
                    hist.Add(token);
                    return;
                }
            }

        }

        public IFace FaceLeft()
        {
            return face1;
        }

        public IFace FaceRight()
        {
            return face2;
        }

        public IEnumerable<Token> getHistory()
        {
            return hist;
        }
    }
}
