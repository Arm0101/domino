namespace Logic
{
    //define cuando se termina el juego
    public interface IFinish
    {
        public string Description();
        bool Finish(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
