using System.Collections.Generic;
using GamePlay.Bullets;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Bullets
{
    public class BulletSpawner : ISpawner<Bullet>
    {
        private IFactoryProvider<Bullet> _factoryProvider;
        private IFactory<Bullet> _factory;
        public List<Bullet> AllObject { get; } = new();

        [Inject]
        private void Construct(IFactoryProvider<Bullet> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }


        public Bullet Spawn(string key, Vector3 position)
        {
            _factory = _factoryProvider.Provide(key);
            Bullet bullet = _factory.Create();
            Quaternion lookRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 0));
            AllObject.Add(bullet);
            return bullet;
        }
    }
}