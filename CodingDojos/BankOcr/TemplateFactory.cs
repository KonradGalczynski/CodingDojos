using System;

namespace BankOcr
{
    public class TemplateFactory
    {
        public static Template CreateFromPattern(string[] pattern, string value)
        {
            return CreateFromPredicate(input =>
                {
                    for (var i = 0; i < pattern.Length; ++i)
                    for (var j = 0; j < pattern[i].Length; ++j)
                        if (pattern[i][j] != input[i][j])
                            return false;
                    return true;
                }
                , value);
        }

        public static Template CreateFromPredicate(Predicate<string[]> predicate, string value)
        {
            return new Template(predicate, value);
        }
    }
}