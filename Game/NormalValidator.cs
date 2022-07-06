using Logic;

namespace Game
{
    public class NormalValidator : IValidator
    {
        public bool Validate(ITable table, IToken token)
        {
            List<IFace> lastFaces = table.getCurrentFaces().ToList();
            if (lastFaces.Count == 0) return true;

            foreach (var t in token.GetFaces())
            {
                if (lastFaces.Contains(t)) return true;
            }

            return false;
        }
    }
}
