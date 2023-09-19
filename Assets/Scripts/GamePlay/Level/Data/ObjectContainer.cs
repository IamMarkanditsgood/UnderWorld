using System;
using System.Collections;
using System.Collections.Generic;
using PoolObjectSystem;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectContainer : MonoBehaviour
{
    [SerializeField] private int _countOfEnemyPool = 5;
    [SerializeField] private LevelData _levelData;

    private ObjectPool _enemies;
    
    private void Awake()
    {
        _enemies = new ObjectPool(_levelData.PrefabContainer.EnemyPrefab, _countOfEnemyPool, _levelData.EnemyContainer);
    }

    public ObjectPool Enemies
    {
        get => _enemies;
        set => _enemies = value;
    }
}
