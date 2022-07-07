using Logic;

namespace Game
{
    public class NormalValidator : IValidator
    {
        public bool Validate(ITable table, Token token)
        {
            List<IFace> lastFaces = new List<IFace> { table.FaceLeft(), table.FaceRight()};
            
            if (lastFaces.Count == 0) return true;

            if (lastFaces.Contains(token.Face1) || lastFaces.Contains(token.Face2)) return true;

            return false;
        }
    }
}
