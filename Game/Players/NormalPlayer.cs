using Logic;

namespace Game
{
    public class NormalPlayer : IPlayer
    {

        public virtual string Description() => "Juega la primera ficha valida";
        protected string id;
        protected List<Token> tokens;
        public NormalPlayer(string _id)
        {

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

        public virtual (Token, IFace) selectToken(ITable table, History history)
        {
            List<IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft() };

            //se juega la primera ficha valida
            foreach (Token token in tokens)
            {
                if (table.Validate(this, token, curr_faces[0], history)) return (token, curr_faces[0]);
                if (table.Validate(this, token, curr_faces[1], history)) return (token, curr_faces[1]);

            }

            return (null, null);
        }
    }
}
