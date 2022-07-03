
namespace Logic
{
    public class Player {
        public List<Token> tokens;
        private bool passed = false;
        private string id;
        public string ID { set { } get { return id; } }
        public Player(string _id) {
            id = _id;
            tokens = new List<Token>();
        }
        public (Token, int) selectToken(Table table) {
            passed = false;



            if (table.History.Count == 0)
            {

                return (tokens[0], tokens[0].Values[0]);
            } 

            foreach (var token in tokens)
            {
                foreach (var v in token.Values) {
                    if (table.LastFaces.Contains(v)) {
                        tokens.Remove(token);
                        return (token, v);
                    }
                }
            }
            passed = true;
            return (null, int.MaxValue);
        }
        public bool isPassed() {
            return passed;
            
        }
        
    }
}