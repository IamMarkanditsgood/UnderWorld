using System;
using GamePlay.Level.ScriptableObjects;
using UnityEngine;

namespace GamePlay.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private PrefabsConfig _prefabContainer;
        [SerializeField] private ObjectContainer _objectContainer;
        [SerializeField] private Transform _enemyContainer;
        [SerializeField] private Transform _bulletsContainer;
        [SerializeField] private Transform _minesContainer;
        [SerializeField] private Transform _turretContainer;

        public PrefabsConfig PrefabContainer => _prefabContainer;
        public ObjectContainer ObjectContainer => _objectContainer;
        public Transform EnemyContainer => _enemyContainer;
        public Transform BulletsContainer => _bulletsContainer;
        public Transform MinesContainer => _minesContainer;
        public Transform TurretContainer => _turretContainer;
        
    }
}
