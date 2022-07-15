namespace Logic
{
    //define la forma en la que se generaran el conjunto de fichas que se utilizaran
    public interface IGenerator
    {
        public string Description();
        public IEnumerable<Token> generateTokens(int n);
    }

}
