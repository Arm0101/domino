namespace Logic
{
    //define el valor y cando una cara es igual a otra
    public interface IFace : IEquatable<IFace>
    {
        public int GetValue();
        public string getRepresentation();

        public IFace GetInstance();
    }
}
