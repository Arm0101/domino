
namespace Logic
{
    public class Player {
        public List<IToken> tokens;
        private bool passed = false;
        private string id;
        public string ID { set { } get { return id; } }
        public Player(string _id) {
            id = _id;
            tokens = new List<IToken>();
        }
        public (IToken, IFace) selectToken(Table table) {
            passed = false;



            if (table.History.Count == 0)
            {

                return (tokens[0], tokens[0].GetFaces().ToArray()[0]);
            } 

            foreach (var token in tokens)
            {
                foreach (var v in token.GetFaces()) {
                    if (table.LastFaces.Contains(v)) {
                        tokens.Remove(token);
                        return (token, v);
                    }
                }
            }
            passed = true;
            return (null, null);
        }
        public bool isPassed() {
            return passed;
            
        }
        
    }
}