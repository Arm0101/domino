using Logic;

namespace Game
    {
    public class PlayMostValuable : NormalPlayer
    {
        public PlayMostValuable(string _id) : base(_id)
        {
        }
        public override (Token, IFace) selectToken(ITable table, History history) {

            Token token = null;
            IFace face = null;
            int max_value = int.MinValue;
            List<IFace> curr_faces = new List<IFace>() { table.FaceRight(), table.FaceLeft() };
            foreach (var t in tokens)
            {
                if (!table.Validate(this, t, history)) continue;
                int val = value(t);
                if (max_value < val)
                {
                    token = t;
                    max_value = val;
                    if (curr_faces.Contains(t.Face1)) face = t.Face1;
                    if (curr_faces.Contains(t.Face2)) face = t.Face2;
                    
                }
            }
            return (token, face);
        }
        private int value(Token token) {
            if (token == null) return -1;
            return (token.Face1.GetValue() + token.Face2.GetValue());
        }

    }

}
