using System.Collections.Generic;
using System.Linq;

namespace BankOcr
{
    public class InputFormatter : IInputFormatter
    {
        public IReadOnlyCollection<IReadOnlyCollection<char[][]>> Format(IEnumerable<string> input)
        {
            var enumerable = input?.ToList();
            if (input == null || !enumerable.Any()) return new List<IReadOnlyCollection<char[][]>>();
            var result = new List<List<char[][]>>();
            var inputEntriesCount = enumerable.Count / 4;
            for (var i = 0; i < inputEntriesCount; i++) result.Add(new List<char[][]>());

            foreach (var element in result)
                for (var i = 0; i < 9; i++)
                {
                    element.Add(new char[3][]);
                    element[i][0] = new char[3];
                    element[i][1] = new char[3];
                    element[i][2] = new char[3];
                }

            var row = 0;
            for (var j = 0; j < enumerable.Count; j++)
            {
                if (string.IsNullOrEmpty(enumerable[j]))
                {
                    row = 0;
                    continue;
                }

                var entry = j / 4;
                result[entry][0][row] = enumerable[j].Substring(0, 3).ToCharArray();
                result[entry][1][row] = enumerable[j].Substring(3, 3).ToCharArray();
                result[entry][2][row] = enumerable[j].Substring(6, 3).ToCharArray();
                result[entry][3][row] = enumerable[j].Substring(9, 3).ToCharArray();
                result[entry][4][row] = enumerable[j].Substring(12, 3).ToCharArray();
                result[entry][5][row] = enumerable[j].Substring(15, 3).ToCharArray();
                result[entry][6][row] = enumerable[j].Substring(18, 3).ToCharArray();
                result[entry][7][row] = enumerable[j].Substring(21, 3).ToCharArray();
                result[entry][8][row] = enumerable[j].Substring(24, 3).ToCharArray();
                row++;
            }


            return result;
        }
    }
}