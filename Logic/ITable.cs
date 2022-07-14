
namespace Logic
{
    //define como se validan y agregan las fichas a la mesa
    public interface ITable
    {
        public string Description();
        public void addToken(Token token, IFace face);
        //caras disponibles en la mesa por donde se jugaran
        public IFace FaceLeft(); 
        public IFace FaceRight();
        //historial de fichas jugadas
        public IEnumerable<Token> getHistory();
        //validar fichas
        bool Validate(IPlayer player,Token ? token,IFace face ,History history);
        public ITable GetInstance();
    }
}
