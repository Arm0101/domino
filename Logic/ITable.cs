
namespace Logic
{
    public interface ITable
    {
        public void addToken(Token token, IFace face);
        public IFace FaceLeft();
        public IFace FaceRight();
        public IEnumerable<Token> getHistory();
        bool Validate(IPlayer player,Token token, History history);
    }
}
