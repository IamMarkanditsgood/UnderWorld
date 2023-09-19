using System.Collections;
using System.Collections.Generic;
using GamePlay.Level.Data;
using PoolObjectSystem;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private PrefabContainer _prefabContainer;
    [SerializeField] private ObjectContainer _objectContainer;
    [SerializeField] private Transform _enemyContainer;

    public Transform EnemyContainer => _enemyContainer;
    public PrefabContainer PrefabContainer => _prefabContainer;
    public ObjectContainer ObjectContainer => _objectContainer;

}
