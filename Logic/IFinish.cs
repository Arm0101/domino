namespace Logic
{
    public interface IFinish
    {
        public string Description();
        bool Finish(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
