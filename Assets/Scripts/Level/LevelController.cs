using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class LevelController : MonoBehaviour
{
    [SerializeField] private LevelData _levelData;
    
    private LevelModel _levelModel = new LevelModel();
    private LevelViev _levelViev = new LevelViev();
    private ObjectPool objectPool = new ObjectPool();

    private void Awake()
    {
        
        //objectPool.CreateObjectForPool(_levelData.ObjectContainer.FreeEnemies, _levelData.PrefabContainer.Enemy);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject obj = objectPool.GetObjectFromPool(_levelData.ObjectContainer.FreeEnemies,
                _levelData.ObjectContainer.EnemiesInUse, _levelData.PrefabContainer.Enemy);
            Debug.Log(obj);
        }
    }
}
