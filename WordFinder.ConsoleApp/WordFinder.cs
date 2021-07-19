using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace WordFinder.ConsoleApp
{
    public class WordFinder
    {
        private readonly Matrix _matrix;
        private readonly Dictionary<string, int> _wordRank = new();
        
        public WordFinder(IEnumerable<string> matrix)
        {
            _matrix = matrix.ToList();
        }

        public IEnumerable<string> Find(IEnumerable<string> wordStream)
        {
            var wordsToFind = wordStream
                .Distinct()
                .ToList();
            
            this.SetWordRank(wordsToFind);
            
            foreach (var word in wordsToFind)
            {
                var occurrences = _matrix.SearchOccurrences(word);
                if (occurrences > 0)
                {
                    this.AddWordRank(word, occurrences);
                }
            }
            
            return this.SortWordRank();
        }

        private IEnumerable<string> SortWordRank()
        {
            return _wordRank
                .Where(x => x.Value > 0)
                .OrderByDescending(x => x.Value)
                .Select(x => x.Key)
                .ToList();
        }

        private void SetWordRank(IEnumerable<string> wordsToFind)
        {
            _wordRank.Clear();
            foreach (var word in wordsToFind)
            {
                _wordRank.Add(word, 0);
            }
        }

        private void AddWordRank(string word, int rank)
        {
            _wordRank[word] += rank;
        }
    }
}