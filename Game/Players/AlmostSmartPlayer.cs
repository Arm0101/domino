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

            Token token = null;
            IFace face = null;

            List<IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft() };
            int count = int.MinValue;

            if (curr_faces[0] == null && curr_faces[1] == null)
            {
                foreach (Token t in tokens)
                {
                    if (table.Validate(this, t, history))
                    {

                        IFace f = null;

                        if (curr_faces.Contains(t.Face1)) f = t.Face1;
                        if (curr_faces.Contains(t.Face2)) f = t.Face2;


                        return (t, f);
                    }

                }
            }



            foreach (var t in tokens)
            {
                
                int currentCount = 0;
                if (!table.Validate(this, t, history)) continue;
                if (curr_faces.Contains(t.Face1)) {

                    ITable aux_table = table.GetInstance();
                    aux_table.addToken(t, t.Face1);
                    currentCount = CountValidTokens(aux_table,history,t);

                    if (currentCount >= count)
                    {
                        count = currentCount;
                        face = t.Face1;
                        token = t;
                    }
                    
                }
                if (curr_faces.Contains(t.Face2)) {
                    ITable aux_table = table.GetInstance();
                    aux_table.addToken(t, t.Face1);
                    currentCount = CountValidTokens(aux_table, history, t);
                    if (currentCount >= count)
                    {
                        count = currentCount;
                        face = t.Face2;
                        token = t;
                    }
                }
                
                
            }
            return (token, face);
        }

        private int CountValidTokens(ITable table ,History history, Token token)
        {
            int count = 0;
            foreach (var t in tokens)
            {
                if (table.Validate(this, t, history)) count++;
            }
            return count;
        }
      
    }
}
