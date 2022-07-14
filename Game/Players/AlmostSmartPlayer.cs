using Logic;

namespace Game
{
    public class AlmostSmartPlayer : NormalPlayer
    {
        public override string Description() => "Juega la ficha que lo deje con mas opciones despues de la jugada";
        public AlmostSmartPlayer(string _id) : base(_id)
        {
        }

        public override (Token, IFace) selectToken(ITable table, History history)
        {

            //ficha y cara que se va a devolver
            Token token = null;
            IFace face = null;
            //caras por donde se puede jugar
            List<IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft() };
            int count = int.MinValue;

            //no se ha jugado todavia
            if (curr_faces[0] == null && curr_faces[1] == null)
            {
                foreach (Token t in tokens)
                {

                    //Se busca la primera ficha valida
                    if (table.Validate(this, t, curr_faces[0], history)) return (t, curr_faces[0]);
                    if (table.Validate(this, t, curr_faces[0], history)) return (t, curr_faces[1]);

                }
            }



            foreach (var t in tokens)
            {
                
                int currentCount = 0;//cantidad de fichas validas despues que se pone una ficha
                
                //si es valido jugar por esta cara
                if (table.Validate(this, t, curr_faces[0], history)) { 
          
                    //se crea una mesa auxiliar y se agrega la ficha
                    ITable aux_table = table.GetInstance();
                    aux_table.addToken(t, curr_faces[0]);
                    currentCount = CountValidTokens(aux_table, history);
                    //si la ficha deja al jugador con mas fichas validas se actualiza la mejor ficha
                    if (currentCount >= count)
                    {
                        count = currentCount;
                        face = curr_faces[0];
                        token = t;
                    }
                    
                }
                if (table.Validate(this, t, curr_faces[1], history))
                {
                    ITable aux_table = table.GetInstance();
                    aux_table.addToken(t, curr_faces[1]);
                    currentCount = CountValidTokens(aux_table, history);
                    if (currentCount >= count)
                    {
                        count = currentCount;
                        face = curr_faces[1];
                        token = t;
                    }
                }
                
                
            }
            return (token, face);
        }

        //contar la cantidad de fichas validas para una mesa
        private int CountValidTokens(ITable table, History history)
        {
            int count = 0;
            foreach (var t in tokens)
            {
                if (table.Validate(this, t, table.FaceLeft(), history)) { count++; continue; }
                if (table.Validate(this, t, table.FaceRight(), history)) count++;
            }
            return count;
        }
      
    }
}
