using Zenject;

namespace Services.Factories
{
    public interface IFactoryProvider<T>
    {
        IFactory<T> Provide(string key);
    }
}