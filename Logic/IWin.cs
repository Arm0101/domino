

namespace Logic
{
    public interface IWin
    {
        IPlayer[] getWiner(Table table, IPlayer[] players, History history);
    }
}
