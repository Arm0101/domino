

namespace Logic
{
    public interface IWin
    {
        public string Description();
        IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
