using System.Collections.Generic;
using GamePlay.Entities.Enemy;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Bullets.Movers
{
    public class AimedBullet : BaseMover
    {
        private ObjectContainer _objectContainer;
        private List<Enemy> _enemiesPool;
        private ISpawner<Enemy> _enemy;

        public override void Move(GameObject bullet, float speed)
        {
            base.Move(bullet, speed);
            
            _enemiesPool = _enemy.AllObject;
            Enemy enemy = GetClosestEnemy(bullet, _enemiesPool);
            bullet.transform.LookAt(enemy.gameObject.transform);
            
        }

        private Enemy GetClosestEnemy(GameObject bullet, List<Enemy> enemiesPool)
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
        private void Constract(ISpawner<Enemy> enemy)
        {
            _enemy = enemy;
        }
    }
}
