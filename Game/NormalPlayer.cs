using Logic;

namespace Game
{
    public class NormalPlayer : IPlayer
    {
        private string id;
        List<IToken> tokens;
        public NormalPlayer(string _id) {

            tokens = new List<IToken>();
            id = _id;
        }
        public void addToken(IToken token)
        {
            tokens.Add(token);
        }

        public string getID()
        {
           return id;
        }

        public IEnumerable<IToken> getTokens()
        {
            return tokens;
        }

        public (IToken, IFace) selectToken(Table table, IValidator validator)
        {

            if (table.LastFaces.Count == 0)
            {

                IFace f = tokens[0].GetFaces().ToList()[0];
                IToken t = tokens[0];
                tokens.Remove(t);
                return (t, f);
            }
            foreach (IToken token in tokens) {
                if (validator.Validate(table, token)) {
                    IFace face;
                    List<IFace> faces_token = token.GetFaces().ToList();
                    
                    foreach (var f in table.LastFaces)
                    {
                        if (faces_token.Contains(f))
                        {
                            face = f;
                            tokens.Remove(token);
                            return (token, face);
                        }  
                    }

                   
                }
                
            }

            return (null, null);
        }
    }
}
