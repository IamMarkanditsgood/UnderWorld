using System.Collections.Generic;
using GamePlay.Entities.Mines;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Turrets
{
    public class TurretSpawner : ISpawner<Turret>
    {
        private IFactoryProvider<Turret> _factoryProvider;
        private IFactory<Turret> _factory;
        public List<Turret> AllObject { get; } = new();

        [Inject]
        private void Construct(IFactoryProvider<Turret> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }


        public Turret Spawn(string key, Vector3 position)
        {
            _factory = _factoryProvider.Provide(key);
            Turret enemy = _factory.Create();
            Quaternion lookRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 0));
            
            AllObject.Add(enemy);
            return enemy;
        }
    }
}