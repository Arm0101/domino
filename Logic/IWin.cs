

namespace Logic
{
    public interface IWin
    {
        IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
