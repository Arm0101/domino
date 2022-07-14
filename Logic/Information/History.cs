
namespace Logic
{
    public class History
    {
        private List<string> id_player; //historial de jugadores
        private List<Token> tokens;//historial de fichas de los jugadores
       
        public History() { 
            id_player = new List<string>();
            tokens = new List<Token>();
        }
       
        public List<string> IdHistory { get{ return id_player; } set { } }
        public List<Token> TokensHistory { set { } get { return tokens; } }

        //agregar jugador y ficha al historial
        public void log(string id, Token token)
        {
            id_player.Add(id);
            tokens.Add(token);

        }

    }
}
