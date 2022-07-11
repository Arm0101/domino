using Logic;
namespace Game
{ 
    public class NormalFace : IFace
    {
        private int value;
        public NormalFace(int val) {
            value = val;
        }
        
        public int GetValue()
        {
            return value;
        }

        public bool Equals(IFace? other)
        {
            return value.Equals(other.GetValue());
        }
        public string getRepresentation() {
            return value.ToString();
        }
        public IFace GetInstance() { 
            return new NormalFace(value);
        }

    }

    
}
