using System.Collections.Generic;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Bullets
{
    public class BulletSpawner : ISpawner<BulletObject>
    {
        private Services.Factories.IFactoryProvider<BulletObject> _factoryProvider;
        private IFactory<BulletObject> _factory;
        public List<BulletObject> AllObject { get; } = new();

        [Inject]
        private void Construct(Services.Factories.IFactoryProvider<BulletObject> factoryProvider)
        {
            _factoryProvider = factoryProvider;
        }


        public BulletObject Spawn(string key, Vector3 position)
        {
            _factory = _factoryProvider.Provide(key);
            BulletObject bulletObject = _factory.Create();
            Quaternion lookRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 180), 0));
            AllObject.Add(bulletObject);
            return bulletObject;
        }
    }
}