namespace Logic
{
    public interface IFinish
    {
        bool Finish(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
