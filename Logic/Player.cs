
namespace Logic
{
    public class Player {
        public List<Token> tokens;
        private string id;
       
        public Player(string _id) { 
            id = _id;
            tokens = new List<Token>();
        }
        public (Token,int) selectToken(Table table) {
            Token t = new Token();
            int value = int.MaxValue;
            foreach (var token in tokens)
            {
                foreach (var v in token.Values) {
                    if (table.LastFaces.Contains(v)) {
                        tokens.Remove(token);
                        return (token, v);
                    }
                }
            }
            return (t,value);
        }
        
    }
}