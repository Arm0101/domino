
namespace Logic
{

    public class Referee
    {
        private IDistribute distribute;
        public Referee(IDistribute _distribute) { 
            distribute = _distribute;
        }

        public void handOutTokens(List<IToken> tokens, IPlayer[] players)

        {
            distribute.HandOutTokens(players, tokens);
          
            
        }

    }
}
