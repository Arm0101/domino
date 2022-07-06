
namespace Logic
{

    public class Referee
    {


        public void handOutTokens(List<IToken> tokens, Player[] players)

        { 

            //random  
            Random  random = new Random();
             for (int i = 0; i < players.Length ; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    int index =  random.Next(0, tokens.Count);
                    players[i].tokens.Add(tokens[index]);
                    tokens.Remove(tokens[index]);
                    
                }
            }
            
        }
        public bool Validate(Table table, IToken token) {
            foreach (var t in token.GetFaces())
            {
                if (table.LastFaces.Contains(t)) return true;
            }

            return false;
        }
    }
}
