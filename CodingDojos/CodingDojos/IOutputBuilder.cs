namespace CodingDojos
{
    public interface IOutputBuilder
    {
        void Append(string message);
        string Build();
    }

    public class NullOutputBuilder : IOutputBuilder
    {
        public void Append(string message)
        {
        }

        public string Build()
        {
            return string.Empty;
        }
    }
}