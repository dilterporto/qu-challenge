using System;
using System.Collections.Generic;

namespace WordFinder.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var input = new List<string>
                {
                    "doneqmatrixdsadadonejhdo",
                    "rgwiodsadjhskdkasdkhkjao",
                    "ahilldsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "uvdxydsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhsoneasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhsoneasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                    "sqnsddsadjhdoneasdkhkjao",
                    "sqnsddsadjhskdkasdkhkjao",
                };
        
                var finder = new WordFinder(input);
                var words = finder
                    .Find(new[] {"chill", "snow", "done", "one", "wind", "wind", "wind"});
            }
            catch (Exception e)
            {
                
            }
        }
    }
}