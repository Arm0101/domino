using Logic;

namespace Game
{
    public class NormalTable : ITable
    {
        private IFace ? face1;
        private IFace ? face2;
        private List<Token> hist;

        public string Description() => "Las fichas se validan y se agregan a la mesa de la forma clasica";
        private NormalTable(IFace f1, IFace f2, List<Token> h) { 
            face1 = f1.GetInstance();
            face2 = f2.GetInstance();
            hist = new List<Token>(h);
        }
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
                    Token aux = new Token(token.Face2, token.Face1);
                    hist.Insert(0, aux);
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
                    Token aux = new Token(token.Face2, token.Face1);
                    hist.Add(aux);
                    return;
                }
            }

        }

        public bool Validate(IPlayer player, Token ? token, History history) {

            if (token is null) return false;
            List<IFace> lastFaces = new List<IFace> { face1, face2 };
            if (lastFaces[0] == null || lastFaces[1] == null) return true;

            if (lastFaces.Contains(token.Face1) || lastFaces.Contains(token.Face2)) return true;

            return false;
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
        public ITable GetInstance() { 
            return new NormalTable(face1,face2,hist);
        }
    }
}
