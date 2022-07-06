using Logic;

namespace Game
{
    public class NormalToken : IToken 
    {

        private IFace[] faces;
        public NormalToken(IFace[] _faces)
        {
            faces = _faces;
        }
        public IEnumerable<IFace> GetFaces()
        {
            return faces;
        }

     
    }
}