using System.Text;

namespace CodingDojos
{
    public class OutputBuilder : IOutputBuilder
    {
        private readonly StringBuilder _stringBuilder;

        public OutputBuilder()
        {
            _stringBuilder = new StringBuilder();
        }

        public void Append(string message)
        {
            _stringBuilder.Append(message);
        }

        public string Build()
        {
            return _stringBuilder.ToString();
        }
    }
}