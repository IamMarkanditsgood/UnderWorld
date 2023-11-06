
using GamePlay.Entities;
using GamePlay.Entities.Bullets;
using GamePlay.Entities.Enemies;
using GamePlay.Entities.Enemies.EnemiesBrains;
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
        private ISpawner<BulletObject> _bulletSpawner ;

        [Inject]
        private void Construct(ISpawner<EnemyControl> enemy, ISpawner<BulletObject> bullet)
        {
            _enemySpawner = enemy;
            _bulletSpawner = bullet;
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.J))
            {
                GameObject obj = _enemySpawner.Spawn("Standart", Vector3.zero).gameObject;
                obj.GetComponent<EnemyControl>().Initialize( new PaladinBrain(_player, _bulletSpawner));
            }
        }
        
    }
}
