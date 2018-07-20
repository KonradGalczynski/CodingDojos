namespace CodingDojos.Builders
{
    public interface IRuleBuilder
    {
        IRuleBuilder RedirectResultTo(IOutputBuilder outputBuilder);
        IRuleBuilder ContinueWith(IRule rule);
        IRuleBuilder BreakIfApplied();
        IRule Build();
    }
}