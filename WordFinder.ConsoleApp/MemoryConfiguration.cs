using System;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;

namespace WordFinder.ConsoleApp
{
    public static class Constants
    {
        public static class MatrixSettings
        {
            public static string MaxSize = $"{nameof(MatrixSettings)}:{nameof(MaxSize)}";
        }
        
        public static class Messages
        {
            public static string InvalidMatrix = $"{nameof(Messages)}:{nameof(InvalidMatrix)}";
            public static string SizeLimitExceeded = $"{nameof(Messages)}:{nameof(SizeLimitExceeded)}";
        }
    }
    
    public class MemoryConfiguration : IConfiguration
    {
        private static readonly IDictionary<string, object> _configurations = new Dictionary<string, object>
        {
            {Constants.MatrixSettings.MaxSize, 64},
            {Constants.Messages.InvalidMatrix, "invalid matrix input"},
            {Constants.Messages.SizeLimitExceeded, "size limit exceeded"},
        };
        
        public IConfigurationSection GetSection(string key)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public string this[string key]
        {
            get => _configurations[key].ToString();
            set => throw new NotImplementedException();
        }
    }
}