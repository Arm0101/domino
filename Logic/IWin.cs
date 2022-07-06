

namespace Logic
{
    public interface IWin
    {
        IEnumerable<IPlayer> getWiner(ITable table, IPlayer[] players, History history);
    }
}
