namespace Logic
{
    public interface IFinish
    {
        bool Finish(ITable table, IPlayer[] players, History history);
    }
}
