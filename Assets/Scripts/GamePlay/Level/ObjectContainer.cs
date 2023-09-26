using Services.PoolObject;
using UnityEngine;

namespace GamePlay.Level
{
    public class ObjectContainer : MonoBehaviour
    {
        [SerializeField] private int _countOfEnemyPool = 5;
        [SerializeField] private LevelController _levelController;

        private ObjectPool _enemies;
    
        public ObjectPool Enemies
        {
            get => _enemies;
            set => _enemies = value;
        }
        private void Awake()
        {
            _enemies = new ObjectPool(_levelController.PrefabContainer.ZombieEnemyPrefab, _countOfEnemyPool, _levelController.EnemyContainer);
        }

    
    }
}
