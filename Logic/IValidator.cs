
namespace Logic
{
    public interface IValidator
    {
        bool Validate(ITable table, Token token);
    }
}
