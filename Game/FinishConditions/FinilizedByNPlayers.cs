using Logic;

namespace Game
{
    public class FinilizedByNPlayers : IFinish
    {
        public string Description() => "El juego finaliza cuando queda 1 solo jugador";
        public bool Finish(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
            //si hay un solo jugador se finaliza el juego
            if (players.ToList().Count == 1) return true;

            //si hay algun jugador que no le quedan fichas se finaliza el juego
            foreach (var item in players)
            {
                if (item.getTokens().ToList().Count == 0) return true;
            }

            return false;
        }
    }
}
