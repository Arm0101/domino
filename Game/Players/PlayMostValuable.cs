using Logic;

namespace Game
    {
    public class PlayMostValuable : NormalPlayer
    {

        public override string Description() => "Juega la ficha que mas valor posea entre las fichas validas";
        public PlayMostValuable(string _id) : base(_id)
        {
        }
        public override (Token, IFace) selectToken(ITable table, History history) {

            Token token = null;
            IFace face = null;
            int max_value = int.MinValue; //guardar mayor valor
            List<IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft() };
            foreach (var t in tokens)
            {
                //si es una jugada valida
                if (table.Validate(this, t, curr_faces[0], history))
                {
                    //se obtiene el valor de la ficha
                    int val = value(t);
                    //si el valor es mayor q la ficha q se habia establecido se actualiza
                    if (max_value < val)
                    {
                        token = t;
                        max_value = val;
                        face = curr_faces[0];

                    }
                }
                if (table.Validate(this, t, curr_faces[1], history))
                {
                    int val = value(t);
                    if (max_value < val)
                    {
                        token = t;
                        max_value = val;
                        face = curr_faces[1];

                    }
                }
            }
            return (token, face);
        }
        //obtener el valor de una ficha
        private int value(Token token) {
            if (token == null) return -1;
            return (token.Face1.GetValue() + token.Face2.GetValue());
        }

    }

}
