

namespace Logic
{
    //define la forma en la que se repartiran las fichas
    public interface IDistribute
    {
        public string Description();
        public void HandOutTokens(IEnumerable<IPlayer> players, List<Token> tokens);
    }
}
