using Logic;

namespace Game
{
    public class NormalFinish : IFinish
    {
        public string Description() => "El juego termina cuando un jugador se queda sin fichas o todos los jugadores se pasan";
        public bool Finish(ITable table, IEnumerable<IPlayer> p, History history)
        {
            IPlayer[] players = p.ToArray();
           
            //si hay algun jugador que no tiene fichas se finaliza el juego
            foreach (var item in players)
            {
                if (item.getTokens().ToList().Count == 0) return true;
            }
           
            //comprobamos si se han jugado tantas fichas como la cantida de jugadores 
            if (history.TokensHistory.Count >= players.Length) {
               List <string> visited = new List <string>(); 
                
                //se empieza a comprobar por las ultimas jugadas
                for (int i = history.TokensHistory.Count - 1; i >= 0; i--) {
                    string id = history.IdHistory[i]; //se obtiene el id del jugador que puso la ficha i-esima
                    if (visited.Contains(id)) continue;//se ignora en caso de que ya se habia comprobado la ultima ficha del jugador
                    visited.Add(id);
                   
                    if (history.TokensHistory[i] != null) return false; //si existe un jugador que en su ultima jugada no se 
                    //se haya pasado el juego continua;
                    //si se comprbaron las ultimas jugadas de todos los jugadores y todos se pasaron el juego finaliza
                    if (visited.Count == players.Length) return true;


                 }
            }

            return false;
        }
    }
}
