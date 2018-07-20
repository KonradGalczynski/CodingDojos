namespace CodingDojos.Rules
{
    public interface IRule
    {
        void Apply(int input);

    }

    public class NullRule : IRule
    {
        public void Apply(int input)
        {
        }
    }
}