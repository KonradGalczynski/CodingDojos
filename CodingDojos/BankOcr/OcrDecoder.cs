using System;
using System.Collections.Generic;
using System.Linq;

namespace BankOcr
{
    public class OcrDecoder
    {
        private readonly List<Template> _templates;

        public OcrDecoder(List<Template> templates)
        {
            _templates = templates;
        }

        public string DecodeLine(string pattern)
        {
            var rows = pattern.Split(new [] {'\n'}, StringSplitOptions.RemoveEmptyEntries);
            var result = string.Empty;

            for (var i = 0; i < rows[0].Length; i += 3)
            {
                var segment = GetSegment(rows, i);
                result += _templates.First(t => t.Match(segment)).Value(); 
            }

            return result;
        }

        private static string[] GetSegment(IEnumerable<string> rows, int offset)
        {
            return rows.Select(row => row.Substring(offset, 3)).ToArray();
        }
    }
}