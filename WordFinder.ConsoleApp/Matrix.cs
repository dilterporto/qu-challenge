using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.Extensions.Configuration;

namespace WordFinder.ConsoleApp
{
    public class Matrix
    {
        private StringBuilder _charMatrix;
        private int _size;
        private readonly IConfiguration _configuration;

        public Matrix(IList<string> input, IConfiguration configuration)
        {
            _configuration = configuration;
            
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
            var maxSize = int.Parse(_configuration[Constants.MatrixSettings.MaxSize]);
            if (_size > maxSize)
                throw new Exception(_configuration[Constants.Messages.SizeLimitExceeded]);
        }
        
        private void CheckIfIsSquare(IList<string> input)
        {
            try
            {
                var columnSize = Enumerable.Range(0, input.Count)
                    .Select(index => input[index].Length)
                    .Distinct()
                    .Single();

                if (columnSize != input.Count)
                    throw new Exception(_configuration[Constants.Messages.InvalidMatrix]);

                _size = columnSize;
            }
            catch
            {
                throw new Exception(_configuration[Constants.Messages.InvalidMatrix]);
            }
        }

        public int SearchOccurrences(string term)
        {
            return Regex.Matches(_charMatrix.ToString(), term).Count;
        }
        
        public static implicit operator Matrix((List<string> input, IConfiguration configuration) init)
        {
            var (input, configuration) = init;
            return new Matrix(input, configuration);
        }
    }
}