using Logic;
namespace Game
{
    public class AdditionTable : ITable
    {
        private IFace? face1;
        private IFace? face2;
        private List<Token> hist;
        public AdditionTable()
        {
            hist = new List<Token>();
        }
        public void addToken(Token token, IFace value = null)
        {
            if (face1 == null && face2 == null)
            {
                face1 = token.Face1;
                face2 = token.Face2;
                hist.Add(token);
                return;
            }
            int val = token.Face1.GetValue() + token.Face2.GetValue();
         
                if (face1.GetValue().Equals(val))
                {
                    face1 = token.Face1;
                  
                    hist.Insert(0, token);
                    return;
                }
                if (face2.GetValue().Equals(val))
                {

                    face2 = token.Face2;
                    hist.Add(token);
                    return;
                }
        }
              


        public bool Validate(IPlayer player, Token? token, History history)
        {

            if (token is null) return false;
            if (face1 is null || face2 is null) return true;
            int val = token.Face1.GetValue() + token.Face2.GetValue();
            return (val == face1.GetValue() || val == face2.GetValue());
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
