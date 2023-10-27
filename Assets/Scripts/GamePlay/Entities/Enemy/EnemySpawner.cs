using System.Collections.Generic;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Enemy
{
    public class EnemySpawner : ISpawner<Enemy>
    {
        private IFactoryProvider<Enemy> _factoryProvider;
        private IFactory<Enemy> _factory;
        public List<Enemy> AllObject { get; } = new();

        [Inject]
        private void Construct(IFactoryProvider<Enemy> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }


        public Enemy Spawn(string key, Vector3 position)
        {
            _factory = _factoryProvider.Provide(key);
            Enemy enemy = _factory.Create();
            Quaternion lookRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 0));
        
            enemy.Initialize();
            AllObject.Add(enemy);
            return enemy;
        }
    }
}