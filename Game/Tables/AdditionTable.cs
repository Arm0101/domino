using Logic;
namespace Game
{
    public class AdditionTable : ITable
    {
        private IFace? face1;
        private IFace? face2;
        private List<Token> hist;

        public string Description() => "Una ficha es valida si la suma de los valores de sus caras es igual a una de las caras disponibles para jugar";
        public AdditionTable()
        {
            hist = new List<Token>();
        }

        private AdditionTable(IFace f1, IFace f2, List<Token> h)
        {
            face1 = f1.GetInstance();
            face2 = f2.GetInstance();
            hist = new List<Token>(h);
        }
        public void addToken(Token token, IFace face)
        {
            //si no se ha jugado aun se agrega la ficha
            if (face1 == null && face2 == null)
            {
                face1 = token.Face1;
                face2 = token.Face2;
                hist.Add(token);
                return;
            }
                //si la cara 1 es igual a la cara por donde se va a jugar
                if (face1.Equals(face))
                {
                    //se actualiza el valor de la cara por donde se puede jugar
                    face1 = token.Face1;
                    //se agrega al principio de la lista
                    hist.Insert(0, token);
                    return;
                }
                if (face2.Equals(face))
                {

                    face2 = token.Face2;
                    hist.Add(token);
                    return;
                }
        }
              


        public bool Validate(IPlayer player, Token? token, IFace face, History history)
        {
            
            if (token is null) return false;
            //si no hay fichas en la mesa cualquier ficha sera valida
            if (face1 is null || face2 is null) return true;

            //se comprueba que la cara que se quiere validar sea una de las dispoibles para jugar
            if (!face.Equals(face1) && !face.Equals(face2)) return false;

            //se comprueba si el valor de la ficha es igual a la cara por donde se quiere jugar
            int val = token.Face1.GetValue() + token.Face2.GetValue();
            return (val == face.GetValue());
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
        public ITable GetInstance()
        {
            
            return new AdditionTable(face1, face2, hist);
        }
    }
}
