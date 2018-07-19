namespace CodingDojos
{
    public interface IOutputBuilder
    {
        void Append(string message);
        string Build();
    }
}