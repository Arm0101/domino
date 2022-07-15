namespace Logic
{
    //define como el jugador escoge la ficha que va a jugar
    public interface IPlayer
    {
        public string Description();
        public (Token, IFace) selectToken(ITable table, History history);
        public void RemoveToken(Token token);
        public void addToken(Token token);
        public IEnumerable<Token> getTokens();
        public string getID();

    }
}
