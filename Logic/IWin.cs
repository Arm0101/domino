namespace Logic
{
    //define que jugadores son los ganadores
    public interface IWin
    {
        public string Description();
        IEnumerable<IPlayer> getWiner(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
