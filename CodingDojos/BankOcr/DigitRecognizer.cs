namespace BankOcr
{
    public class DigitRecognizer : IDigitRecognizer
    {
        public char Recognize(char[][] digit)
        {
            if (digit[0][1] == '_') // 0, 2, 3, 5, 6, 7, 8, 9
            {
                if (digit[1][1] == '_') // 2, 3, 5, 6, 8, 9
                {
                    if (digit[1][2] == '|') // 2, 3, 8, 9
                    {
                        if (digit[2][0] == '|') // 2, 8
                            return digit[1][0] == '|' ? '8' : '2';
                        // 3, 9
                        return digit[1][0] == '|' ? '9' : '3';
                    }

                    // 5, 6
                    return digit[2][0] == '|' ? '6' : '5';
                }

                // 0, 7
                return digit[2][1] == '_' ? '0' : '7';
            }

            // 1, 4, 
            return digit[1][1] == '_' ? '4' : '1';
        }
    }
}