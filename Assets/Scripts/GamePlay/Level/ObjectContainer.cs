using Services.PoolObject;
using UnityEngine;

namespace GamePlay.Level
{
    public class ObjectContainer : MonoBehaviour
    {
        public static ObjectContainer InstanceObjectContainer;
        [SerializeField] private int _countOfEnemyPool = 5;
        [SerializeField] private int _countOfBullets = 5;
        [SerializeField] private int _countOfMinesPool = 5;
        [SerializeField] private int _countOfTurrets = 5;
        [SerializeField] private LevelController _levelController;

        private ObjectPool _enemies;
        private ObjectPool _bullets;
        private ObjectPool _mines;
        private ObjectPool _turrets;
        
        public ObjectPool Enemies
        {
            get => _enemies;
            set => _enemies = value;
        } 
        public ObjectPool Bullets
        {
            get => _bullets;
            set => _bullets = value;
        }
        public ObjectPool Mines
        {
            get => _mines;
            set => _mines = value;
        } 
        public ObjectPool Turrets
        {
            get => _turrets;
            set => _turrets = value;
        }
        private void Awake()
        {
            InstanceObjectContainer = this;
            _enemies = new ObjectPool(_levelController.PrefabContainer.ZombieEnemyPrefab, _countOfEnemyPool, _levelController.EnemyContainer);
            _bullets = new ObjectPool(_levelController.PrefabContainer.Bullet, _countOfBullets, _levelController.BulletsContainer);
            _mines = new ObjectPool(_levelController.PrefabContainer.Mines, _countOfMinesPool,
                _levelController.MinesContainer);
            _turrets = new ObjectPool(_levelController.PrefabContainer.Turrets, _countOfTurrets,
                _levelController.TurretContainer);
        }
    }
}
