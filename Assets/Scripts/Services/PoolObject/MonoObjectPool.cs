using System.Collections;
using Services.PoolObject;
using UnityEngine;
using Zenject;

public class MonoObjectPool : MonoBehaviour
{
    [SerializeField] private string _key;

    [SerializeField] private GameObject _prefab;

    [SerializeField] private bool _isUsedDiContainer;

    [SerializeField] private int _startCount;

    [SerializeField] private Transform _container;

    private ObjectPool _objectPool;
    public string Key => _key;

    public ObjectPool GetObjectPool(DiContainer diContainer)
    {
        return _objectPool ??= new ObjectPool(_prefab, _startCount, _container, _isUsedDiContainer ? diContainer : null);
    }
    
}