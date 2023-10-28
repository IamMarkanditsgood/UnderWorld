using System.Collections.Generic;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Mines
{
    public class MineSpawner  : ISpawner<Mine>
    {
        private Services.Factories.IFactoryProvider<Mine> _factoryProvider;
        private IFactory<Mine> _factory;
        public List<Mine> AllObject { get; } = new();

        [Inject]
        private void Construct(Services.Factories.IFactoryProvider<Mine> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }


        public Mine Spawn(string key, Vector3 position)
        {
            _factory = _factoryProvider.Provide(key);
            Mine enemy = _factory.Create();
            Quaternion lookRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 0));
            
            AllObject.Add(enemy);
            return enemy;
        }
    }
}