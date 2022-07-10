using Logic;

namespace Game
{
    public class NormalPlayer : IPlayer
    {
        private string id;
        List<Token> tokens;
        public NormalPlayer(string _id) {

            tokens = new List<Token>();
            id = _id;
        }
        public void addToken(Token token)
        {
            tokens.Add(token);
        }

        public string getID()
        {
           return id;
        }

        public IEnumerable<Token> getTokens()
        {
            return tokens;
        }

        public (Token, IFace) selectToken(ITable table, History history)
        {
            List <IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft()} ;
            if (curr_faces[0] == null && curr_faces[1] == null)
            {

                IFace f = tokens[0].Face1;
                Token t = tokens[0];
                tokens.Remove(t);
                return (t, f);
            }
            foreach (Token token in tokens) {
                if (table.Validate(this,token,history)) {
                    
                    IFace face = null;

                    if (curr_faces.Contains(token.Face1)) face = token.Face1;
                    if (curr_faces.Contains(token.Face2)) face = token.Face2;
                    tokens.Remove(token);
                    return (token, face);
                }
                
            }

            return (null, null);
        }
    }
}
