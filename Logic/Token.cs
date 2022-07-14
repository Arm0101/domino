namespace Logic
{
    //Representa una ficha con 2 caras de tipo IFace
    public class Token
    {
        private IFace face1, face2;
        public Token(IFace _face1, IFace _face2)
        {
            face1 = _face1;
            face2 = _face2;
        } 
        public IFace Face1 { set { } get { return face1; } }
        public IFace Face2 { set { } get { return face2; } }
        
    }
}
