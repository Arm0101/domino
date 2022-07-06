
namespace Logic
{

    public class Referee
    {
        private IDistribute distribute;
        public Referee(IDistribute _distribute) { 
            distribute = _distribute;
        }

        public void handOutTokens(List<IToken> tokens, Player[] players)

        {
            distribute.HandOutTokens(players, tokens);
          
            
        }
        public bool Validate(Table table, IToken token) {
            foreach (var t in token.GetFaces())
            {
                if (table.LastFaces.Contains(t)) return true;
            }

            return false;
        }
    }
}
