using System;

namespace BankOcr
{
    public class Template
    {
        private readonly Predicate<string[]> _matcher;
        private readonly string _value;

        public Template(Predicate<string[]> matcher, string value)
        {
            _value = value;
            _matcher = matcher;
        }

        public bool Match(string[] input)
        {
            return _matcher(input);
        }

        public string Value()
        {
            return _value;
        }

        public static Template Joker()
        {
            return new Template(s => true, "?");
        }

        public static Template Zero()
        {
            return TemplateFactory.CreateFromPattern(new[]
            {
                " _ ",
                "| |",
                "|_|"
            }, "0");
        }

        public static Template One()
        {
            return TemplateFactory.CreateFromPattern(
                new[] {"   ",
                       "  |",
                       "  |" },
                "1");
        }

        public static Template Two()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    " _|",
                    "|_ "
                },
                "2");
        }

        public static Template Three()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    " _|",
                    " _|"
                },
                "3");
        }

        public static Template Four()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    "   ",
                    "|_|",
                    "  |"
                },
                "4");
        }

        public static Template Five()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    "|_ ",
                    " _|"
                },
                "5");
        }

        public static Template Six()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    "|_ ",
                    "|_|"
                },
                "6");
        }

        public static Template Seven()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    "  |",
                    "  |"
                },
                "7");
        }

        public static Template Eight()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    "|_|",
                    "|_|"
                },
                "8");
        }

        public static Template Nine()
        {
            return TemplateFactory.CreateFromPattern(
                new[]
                {
                    " _ ",
                    "|_|",
                    " _|"
                },
                "9");
        }
    }
}