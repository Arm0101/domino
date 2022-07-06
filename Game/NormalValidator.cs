using Logic;

namespace Game
{
    public class NormalValidator : IValidator
    {
        public bool Validate(Table table, IToken token)
        {
            if (table.LastFaces.Count == 0) return true;

            foreach (var t in token.GetFaces())
            {
                if (table.LastFaces.Contains(t)) return true;
            }

            return false;
        }
    }
}
