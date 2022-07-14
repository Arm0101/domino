using Logic;

namespace Game
{
    public class NormalTable : ITable
    {
        private IFace ? face1;
        private IFace ? face2;
        private List<Token> hist;

        public string Description() => "Las fichas se validan y se agregan a la mesa de la forma clasica";
        private NormalTable(IFace f1, IFace f2, List<Token> h) { 
            face1 = f1.GetInstance();
            face2 = f2.GetInstance();
            hist = new List<Token>(h);
        }
        public NormalTable() {
            hist = new List<Token>();
        }
        public void addToken(Token token, IFace value)
        {
            //si no hay fichas en la mesa se agrega la ficha
            if (face1 == null && face2 == null)
            {
                face1 = token.Face1;
                face2 = token.Face2;
                hist.Add(token);
                return;
            }
            //si la ficha tiene las 2 caras iguales
            if (token.Face1.Equals(token.Face2))
            {
                //se comprueba que cara de la ficha es la q se quiere jugar
                if (value.Equals(face2))
                {
                    hist.Add(token);
                    return;
                }
                else
                {
                    hist.Insert(0, token);
                    return;
                }
            }
            //si la cara que se quiere jugar es la primera
            if (value.Equals(token.Face1))
            {
                //si es igual a la cara izquierda de la mesa
                if (face1.Equals(value))
                {
                    //se actualiza la cara disponible para jugar
                    face1 = token.Face2;
                    //se invierte la ficha para que coincidan las caras
                    Token aux = new Token(token.Face2, token.Face1);
                    //se agrega al principio
                    hist.Insert(0, aux);
                    return ;
                }
                //si es la cara izquierda de la mesa entonces se agrega al principio
                if (face2.Equals(value))
                {
            
                    face2 = token.Face2;
                    hist.Add(token);
                    return;
                }
            }

            //analogo al primer caso
            if (value.Equals(token.Face2))
            {
                if (face1.Equals(value))
                {
                    face1 = token.Face1;
                    hist.Insert(0, token);
                    return;
                }
                if (face2.Equals(value))
                {
                    face2 = token.Face1;
                    Token aux = new Token(token.Face2, token.Face1);
                    hist.Add(aux);
                    return;
                }
            }

        }

        public bool Validate(IPlayer player, Token ? token, IFace face, History history) {

            if (token is null) return false;
           
            //si no hay fichas en la mesa se permitira jugar cualquier ficha
            if (face1 == null || face2 == null) return true;

            //se comprueba que la cara por donde se quiere validar este en la mesa
            if (!face.Equals(face1) && !face.Equals(face2)) return false;


            //se comprueba si una de las caras del token es igual la cara por donde se quiere jugar
            if (token.Face1.Equals(face) || token.Face2.Equals(face)) return true;
            
            return false;
        }

        public IFace FaceLeft()
        {
            return face1;
        }

        public IFace FaceRight()
        {
            return face2;
        }

        public IEnumerable<Token> getHistory()
        {
            return hist;
        }
        public ITable GetInstance() { 
            return new NormalTable(face1,face2,hist);
        }
    }
}
