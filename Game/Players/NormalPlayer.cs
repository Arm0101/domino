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
        public void RemoveToken(Token token)
        {
            if (tokens.Contains(token))
                tokens.Remove(token);
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

        public (Token, IFace ) selectToken(ITable table, History history)
        {
            List <IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft()} ;

            foreach (Token token in tokens) {
                if (table.Validate(this,token,history)) {

                    IFace face = null;

                    if (curr_faces.Contains(token.Face1)) face = token.Face1;
                    if (curr_faces.Contains(token.Face2)) face = token.Face2;
                    
                   
                    return (token, face);
                }
                
            }

            return (null, null);
        }
    }
}
