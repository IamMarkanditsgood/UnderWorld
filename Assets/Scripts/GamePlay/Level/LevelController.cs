using System;
using GamePlay.Entities;
using GamePlay.Entities.Bullets;
using GamePlay.Entities.Enemies;
using GamePlay.Entities.Enemies.EnemiesBrains;
using GamePlay.Entities.Mines;
using GamePlay.Entities.Turrets;
using GamePlay.Level.ScriptableObjects;
using UnityEngine;
using Zenject;

namespace GamePlay.Level
{
    public class LevelController : MonoBehaviour
    {
        [SerializeField] private PrefabsConfig _prefabContainer;
        [SerializeField] private Transform _player;

        public PrefabsConfig PrefabContainer => _prefabContainer;
        private ISpawner<EnemyControl> _enemySpawner;

        [Inject]
        private void Construct(ISpawner<EnemyControl> enemy, ISpawner<BulletObject> bullet, ISpawner<Mine> mine, ISpawner<Turret> turret)
        {
            _enemySpawner = enemy;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameObject obj = _enemySpawner.Spawn("Standart", Vector3.zero).gameObject;
                obj.GetComponent<EnemyControl>().Initialize(new PaladinBrain(_player));
            }
        }
        
    }

    internal class Enemies
    {
    }
}
