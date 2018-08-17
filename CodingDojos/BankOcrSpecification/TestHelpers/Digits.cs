using System.Collections.Generic;

namespace BankOcrSpecification.TestHelpers
{
    public class Digits
    {
        private static readonly char[][] Zero = {
            new[] {' ', '_', ' '},
            new[] {'|', ' ', '|'},
            new[] {'|', '_', '|'}
        };

        private static readonly char[][] One = {
            new[] {' ', ' ', ' '},
            new[] {' ', ' ', '|'},
            new[] {' ', ' ', '|'}
        };

        private static readonly char[][] Two = {
            new[] {' ', '_', ' '},
            new[] {' ', '_', '|'},
            new[] {'|', '_', ' '}
        };

        private static readonly char[][] Three = {
            new[] {' ', '_', ' '},
            new[] {' ', '_', '|'},
            new[] {' ', '_', '|'}
        };

        private static readonly char[][] Four = {
            new[] {' ', ' ', ' '},
            new[] {'|', '_', '|'},
            new[] {' ', ' ', '|'}
        };

        private static readonly char[][] Five = {
            new[] {' ', '_', ' '},
            new[] {'|', '_', ' '},
            new[] {' ', '_', '|'}
        };

        private static readonly char[][] Six = {
            new[] {' ', '_', ' '},
            new[] {'|', '_', ' '},
            new[] {'|', '_', '|'}
        };

        private static readonly char[][] Seven = {
            new[] {' ', '_', ' '},
            new[] {' ', ' ', '|'},
            new[] {' ', ' ', '|'}
        };

        private static readonly char[][] Eight = {
            new[] {' ', '_', ' '},
            new[] {'|', '_', '|'},
            new[] {'|', '_', '|'}
        };

        private static readonly char[][] Nine = {
            new[] {' ', '_', ' '},
            new[] {'|', '_', '|'},
            new[] {' ', '_', '|'}
        };

        public static readonly Dictionary<int, char[][]> DigitsDictionary = new Dictionary<int, char[][]>
        {
            {0, Zero},
            {1, One },
            {2, Two },
            {3, Three },
            {4, Four },
            {5, Five },
            {6, Six },
            {7, Seven },
            {8, Eight },
            {9, Nine }
        };
    }
}