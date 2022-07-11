

namespace Logic
{
    public interface IDistribute
    {
        public void HandOutTokens(IEnumerable<IPlayer> players, List<Token> tokens);
    }
}
