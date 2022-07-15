namespace Logic
{
    //define quien es el jugador siguiente
    public interface IOrder
    {
        public string Description();
        public IPlayer GetPlayer(ITable table, IEnumerable<IPlayer> players, History history);
    }
}
