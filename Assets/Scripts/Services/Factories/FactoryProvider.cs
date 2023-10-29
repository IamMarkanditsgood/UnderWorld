using System.Collections.Generic;
using Zenject;

namespace Services.Factories
{
    public class FactoryProvider<T> : IFactoryProvider<T>
    {
        private readonly Dictionary<string, IFactory<T>> _dictionary;
        
        public FactoryProvider(IEnumerable<KeyValuePair<string, IFactory<T>>> keyValuePairs)
        {
            _dictionary = new Dictionary<string, IFactory<T>>(keyValuePairs);
        }

        public IFactory<T> Provide(string key)
        {
            return _dictionary[key];
        }
    }
}