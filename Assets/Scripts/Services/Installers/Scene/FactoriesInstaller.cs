using System.Collections.Generic;
using GamePlay.Bullets;
using GamePlay.Entities.Bullets;
using GamePlay.Entities.Enemy;
using GamePlay.Entities.Mines;
using GamePlay.Entities.Turrets;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace Services.Installers.Scene
{
    public class FactoriesInstaller: MonoInstaller
    {
        [SerializeField] private List<MonoObjectPool> _enemyPools;
        [SerializeField] private List<MonoObjectPool> _bulletsPools;
        [SerializeField] private List<MonoObjectPool> _minesPools;
        [SerializeField] private List<MonoObjectPool> _turretsPools;

        public override void InstallBindings()
        {
            BindEnemy();
            BindBullet();
            BindMine();
            BindTurret();
        }

        private void BindEnemy()
        {
            FactoryProvider<Enemy> enemyFactoryProvider = CreateFactoryProvider<Enemy>(_enemyPools);
            Container.Bind<IFactoryProvider<Enemy>>().FromInstance(enemyFactoryProvider).AsSingle();
            Container.Bind<ISpawner<Enemy>>().To<EnemySpawner>().AsSingle();
        }
        private void BindBullet()
        {
            FactoryProvider<Bullet> bulletFactoryProvider = CreateFactoryProvider<Bullet>(_bulletsPools);
            Container.Bind<IFactoryProvider<Bullet>>().FromInstance(bulletFactoryProvider).AsSingle();
            Container.Bind<ISpawner<Bullet>>().To<BulletSpawner>().AsSingle();
        }
        private void BindMine()
        {
            FactoryProvider<Mine> mineFactoryProvider = CreateFactoryProvider<Mine>(_minesPools);
            Container.Bind<IFactoryProvider<Mine>>().FromInstance(mineFactoryProvider).AsSingle();
            Container.Bind<ISpawner<Mine>>().To<MineSpawner>().AsSingle();
        }
        private void BindTurret()
        {
            FactoryProvider<Turret> enemyFactoryProvider = CreateFactoryProvider<Turret>(_turretsPools);
            Container.Bind<IFactoryProvider<Turret>>().FromInstance(enemyFactoryProvider).AsSingle();
            Container.Bind<ISpawner<Turret>>().To<TurretSpawner>().AsSingle();
        }

        private FactoryProvider<T> CreateFactoryProvider<T>(List<MonoObjectPool> objectPools) where T : MonoBehaviour
        {
            List<KeyValuePair<string, IFactory<T>>> poolFactories = new();
            foreach (MonoObjectPool pool in objectPools)
            {
                PoolFactory<T> factory = new(pool.GetObjectPool(Container));
                poolFactories.Add(new KeyValuePair<string, IFactory<T>>(pool.Key, factory));
            }

            return new FactoryProvider<T>(poolFactories.ToArray());
        }
    }
}
