using System.Collections.Generic;
using GamePlay.Entities.Enemies;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Bullets.Movers
{
    public class AimedBullet : BaseMover
    {
        private ObjectContainer _objectContainer;
        private List<EnemyControl> _enemiesPool;
        private ISpawner<EnemyControl> _enemy;

        public override void Move(GameObject bullet, float speed)
        {
            base.Move(bullet, speed);
            
            _enemiesPool = _enemy.AllObject;
            EnemyControl enemyControl = GetClosestEnemy(bullet, _enemiesPool);
            bullet.transform.LookAt(enemyControl.gameObject.transform);
            
        }

        private EnemyControl GetClosestEnemy(GameObject bullet, List<EnemyControl> enemiesPool)
        {
            
            float previousDistance = Vector3.Distance(enemiesPool[0].gameObject.transform.position, bullet.transform.position);
            int enemyIndex = 0;
            for (int i = 1; i < enemiesPool.Count; i++)
            {
                float currentDist = Vector3.Distance(enemiesPool[i].gameObject.transform.position, bullet.transform.position);
                if (currentDist < previousDistance)
                {
                    previousDistance = currentDist;
                    enemyIndex = i;
                }
            }
            return enemiesPool[enemyIndex];
        }
        [Inject]
        private void Constract(ISpawner<EnemyControl> enemy)
        {
            _enemy = enemy;
        }
    }
}
