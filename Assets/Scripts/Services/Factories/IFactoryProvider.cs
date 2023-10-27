using Zenject;

public interface IFactoryProvider<T>
{
    IFactory<T> Provide(string key);
}