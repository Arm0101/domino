using Logic;
namespace Game
{
    public class ParImparDistribute : IDistribute
    {
        public string Description() => "Todas las fichas que se le reparten a un jugador tienen valor par o impar ";
        int n_players; //cantidad de fichas por juadores
        public ParImparDistribute(int n)
        {
            n_players = n;
        }
        public void HandOutTokens(IEnumerable<IPlayer> p, List<Token> tokens)
        {
            List<Token> par = new List<Token>();
            List<Token> impar = new List<Token>();
            List<IPlayer> players = p.ToList();
            //separar las fichas por par e impar segun su valor
            foreach (var t in tokens)
            {
                int val = t.Face1.GetValue() + t.Face2.GetValue();
                if (val % 2 == 0) { par.Add(t); }
                else
                {
                    impar.Add(t);
                }
            }


            int i = 0;
            bool par_turn = true; // para alternar entre el tipo de ficha q se le reparte al jugador
            while (i < players.Count)
            {
                Random rand = new Random();
                for (int j = 0; j < n_players; j++)
                {
                    int index;
                    
                    if (par_turn && par.Count > 0) // si es par se toma una ficha aleatoria de la lista de par y se le agrega a un jugador
                    {
                        index = rand.Next(0, par.Count);
                        players[i].addToken(par[index]);
                        tokens.Remove(par[index]);
                        par.RemoveAt(index);
                    }
                    else
                    {
                        //se le agrega la ficha impar 
                        if (!par_turn && impar.Count > 0)
                        {
                            index = rand.Next(0, impar.Count);
                            players[i].addToken(impar[index]);
                            tokens.Remove(impar[index]);
                            impar.RemoveAt(index);
                        }
                    }
                }
                i++; // mover al siguiente jugador
                par_turn = !par_turn; //alternar entre el tipo de par o impar

            }
        }
    }
}

