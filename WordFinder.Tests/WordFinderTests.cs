using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using WordFinder.ConsoleApp;

namespace WordFinder.Tests
{
    [TestFixture]
    public class WordFinderTests
    {
        private IList<string> _matrix;
        private IConfiguration _configuration;
        private Matrix CreateNewMatrix(IList<string> matrix)
        {
            return new(matrix, _configuration);
        }

        [SetUp]
        public void Setup()
        {
            _configuration = new MemoryConfiguration();
            _matrix = new List<string>
            {
                "abcdc",
                "fgwio",
                "chill",
                "pqnsd",
                "uvdxy"
            };
        }

        [Test]
        public void GivenAWordstreamWith4WordsAndMatrixMatchingJust3ShouldReturnJust3()
        {
            // arrange
            var wordstream = new List<string>() {"cold", "wind", "snow", "chill"};
            
            // act
            IWordFinder wordFinder = new ConsoleApp.WordFinder(_matrix, _configuration);
            var found = wordFinder.Find(wordstream);

            // assert
            Assert.AreEqual(3, found.Count());
            Assert.True(!found.Contains("snow"));
        }

        [Test]
        public void GivenAnEmptyWordstreamShouldReturnAnEmptyWordsList()
        {
            // arrange
            var wordstream = new List<string>();
            
            // act
            IWordFinder wordFinder = new ConsoleApp.WordFinder(_matrix, _configuration);
            var found = wordFinder.Find(wordstream);
            
            // assert
            Assert.IsEmpty(found);
        }
    }
}