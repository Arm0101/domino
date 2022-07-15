using Logic;

namespace Game
{
    public class CharFace : IFace
    {
        private int value;
        private char repr;

        private CharFace(int value, char repr)
        {
            this.value = value;
            this.repr = repr;
        }

        public CharFace(char val)
        {
            repr = val;
            int count = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                if (val == i) { value = count; break; }

                count++;
            }
        }

        public int GetValue()
        {
            return value;
        }

        public bool Equals(IFace? other)
        {
            return value.Equals(other.GetValue());
        }
        public string getRepresentation()
        {
            return repr.ToString();
        }
        public IFace GetInstance()
        {
            return new CharFace(value, repr);
        }

    }
}
