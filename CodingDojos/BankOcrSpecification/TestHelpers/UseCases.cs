namespace BankOcrSpecification.TestHelpers
{
    public class UseCases
    {
        public const string GivenZeros = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                         "| || || || || || || || || |" + "\n" +
                                         "|_||_||_||_||_||_||_||_||_|" + "\n";

        public const string ExpectedZeros = "000000000";

        public const string GivenOnes = "                           " + "\n" +
                                        "  |  |  |  |  |  |  |  |  |" + "\n" +
                                        "  |  |  |  |  |  |  |  |  |" + "\n";

        public const string ExpectedOnes = "111111111";

        public const string GivenTwos = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                        " _| _| _| _| _| _| _| _| _|" + "\n" +
                                        "|_ |_ |_ |_ |_ |_ |_ |_ |_ " + "\n";

        public const string ExpectedTwos = "222222222";

        public const string GivenThrees = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                          " _| _| _| _| _| _| _| _| _|" + "\n" +
                                          " _| _| _| _| _| _| _| _| _|" + "\n";

        public const string ExpectedThrees = "333333333";

        public const string GivenFours = "                           " + "\n" +
                                         "|_||_||_||_||_||_||_||_||_|" + "\n" +
                                         "  |  |  |  |  |  |  |  |  |" + "\n";

        public const string ExpectedFours = "444444444";

        public const string GivenFives = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                         "|_ |_ |_ |_ |_ |_ |_ |_ |_ " + "\n" +
                                         " _| _| _| _| _| _| _| _| _|" + "\n";

        public const string ExpectedFives = "555555555";

        public const string GivenSixes = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                         "|_ |_ |_ |_ |_ |_ |_ |_ |_ " + "\n" +
                                         "|_||_||_||_||_||_||_||_||_|" + "\n";

        public const string ExpectedSixes = "666666666";

        public const string GivenSevens = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                          "  |  |  |  |  |  |  |  |  |" + "\n" +
                                          "  |  |  |  |  |  |  |  |  |" + "\n";

        public const string ExpectedSevens = "777777777";

        public const string GivenEights = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                          "|_||_||_||_||_||_||_||_||_|" + "\n" +
                                          "|_||_||_||_||_||_||_||_||_|" + "\n";

        public const string ExpectedEights = "888888888";

        public const string GivenNines = " _  _  _  _  _  _  _  _  _ " + "\n" +
                                         "|_||_||_||_||_||_||_||_||_|" + "\n" +
                                         " _| _| _| _| _| _| _| _| _|" + "\n";

        public const string ExpectedNines = "999999999";

        public const string GivenFullHouse = "    _  _     _  _  _  _  _ " + "\n" +
                                             "  | _| _||_||_ |_   ||_||_|" + "\n" +
                                             "  ||_  _|  | _||_|  ||_| _|" + "\n";

        public const string ExpectedFullHouse = "123456789";

        public const string GivenJoker =     "    _  _     _  _  _  _  _ " + "\n" +
                                             "  | _| _||_| _ |_   ||_||_|" + "\n" +
                                             "  ||_  _|  | _||_|  ||_| _|" + "\n";

        public const string ExpectedQuestionMark = "1234?6789";
    }
}