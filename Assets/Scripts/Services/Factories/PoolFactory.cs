using Services.PoolObject;
using UnityEngine;
using Zenject;

public class PoolFactory<T> : IFactory<T> where T : MonoBehaviour
{
    private readonly ObjectPool _objectPool;

    public PoolFactory(ObjectPool objectPool)
    {
        _objectPool = objectPool;
    }

    public T Create()
    {
        GameObject obj = _objectPool.GetFreeElement();
        return obj.GetComponent<T>();
    }
}