using System.Collections.Generic;
using System.Linq;

namespace BankOcr
{
    public class InputFormatter : IInputFormatter
    {
        public IReadOnlyCollection<IReadOnlyCollection<char[][]>> Format(IEnumerable<string> input)
        {
            var enumerable = input?.ToList();
            if (input == null || !enumerable.Any())
            {
                return new List<IReadOnlyCollection<char[][]>>();
            }

            var result = new List<List<char[][]>>();
            for (var i = 0; i < enumerable.Count / 4; i++)
            {
                result.Add(new List<char[][]>());
            }

            foreach (var element in result)
            {
                for (var i = 0; i < 9; i++)
                {
                    element.Add(new char[3][]);
                    element[i][0] = new char[3];
                    element[i][1] = new char[3];
                    element[i][2] = new char[3];
                }
            }

            for (var i = 0; i < enumerable.Count - 1; i++)
            {
                result[0][0][i] = enumerable[i].Substring(0, 3).ToCharArray();
                result[0][1][i] = enumerable[i].Substring(3, 3).ToCharArray();
                result[0][2][i] = enumerable[i].Substring(6, 3).ToCharArray();
                result[0][3][i] = enumerable[i].Substring(9, 3).ToCharArray();
                result[0][4][i] = enumerable[i].Substring(12, 3).ToCharArray();
                result[0][5][i] = enumerable[i].Substring(15, 3).ToCharArray();
                result[0][6][i] = enumerable[i].Substring(18, 3).ToCharArray();
                result[0][7][i] = enumerable[i].Substring(21, 3).ToCharArray();
                result[0][8][i] = enumerable[i].Substring(24, 3).ToCharArray();
            }

            return result;
        }
    }
}