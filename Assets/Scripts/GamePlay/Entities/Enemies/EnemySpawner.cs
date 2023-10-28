using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Enemies
{
    public class EnemySpawner : ISpawner<Enemies.EnemyControl>
    {
        private Services.Factories.IFactoryProvider<Enemies.EnemyControl> _factoryProvider;
        private IFactory<Enemies.EnemyControl> _factory;
        public List<Enemies.EnemyControl> AllObject { get; } = new();

        [Inject]
        private void Construct(Services.Factories.IFactoryProvider<Enemies.EnemyControl> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }


        public Enemies.EnemyControl Spawn(string key, Vector3 position)
        {
            _factory = _factoryProvider.Provide(key);
            Enemies.EnemyControl enemyControl = _factory.Create();
            Quaternion lookRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 0));
        
            enemyControl.Initialize();
            AllObject.Add(enemyControl);
            return enemyControl;
        }
    }
}