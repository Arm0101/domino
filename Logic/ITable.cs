
namespace Logic
{
    public interface ITable
    {
        public void addToken(IToken token, IFace face);
        public IEnumerable<IFace> getCurrentFaces();
        public IEnumerable<IToken> getHistory();
    }
}
