using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace WordFinder.ConsoleApp
{
    public class Matrix
    {
        private const int MAX_SIZE = 64;
        private StringBuilder _charMatrix;
        private int _size;

        private Matrix(IList<string> input)
        {
            this.CheckIfIsSquare(input);
            this.CheckSizeLimit();
            this.IndexContent(input);
        }

        private void IndexContent(IList<string> input)
        {
            _charMatrix = new StringBuilder();
            _charMatrix.Append(string.Join(string.Empty, input));

            var matrixTransposed = input
                .Select((_, i) => input.Select(x => x[i])
                    .ToArray())
                .Select(item => new string(item))
                .ToList();

            _charMatrix.Append(string.Join(string.Empty, matrixTransposed));
        }

        private void CheckSizeLimit()
        {
            if (_size > MAX_SIZE)
                throw new Exception("size limit exceeded");
        }
        
        private void CheckIfIsSquare(IList<string> input)
        {
            const string message = "invalid matrix input";
            try
            {
                var columnSize = Enumerable.Range(0, input.Count)
                    .Select(index => input[index].Length)
                    .Distinct()
                    .Single();
                
                if (columnSize != input.Count)
                    throw new Exception(message);

                _size = columnSize;
            }
            catch
            {
                throw new Exception(message);
            }
        }

        public int SearchOccurrences(string term)
        {
            return Regex.Matches(_charMatrix.ToString(), term).Count;
        }
        
        public static implicit operator Matrix(List<string> input)
        {
            return new(input);
        }
    }
}