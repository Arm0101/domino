

namespace Logic
{
    public interface IDistribute
    {
        public string Description();
        public void HandOutTokens(IEnumerable<IPlayer> players, List<Token> tokens);
    }
}
