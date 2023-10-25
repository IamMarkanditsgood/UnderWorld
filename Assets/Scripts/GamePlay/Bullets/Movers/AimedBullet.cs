using System.Collections.Generic;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Bullets.Movers
{
    public class AimedBullet : BaseMover
    {
        private ObjectContainer _objectContainer;
        private List<GameObject> _enemiesPool;
        public override void Move(GameObject bullet, float speed)
        {
            _objectContainer = ObjectContainer.InstanceObjectContainer;
            base.Move(bullet, speed);
            
            _enemiesPool = _objectContainer.Enemies.EnabledPool;
            GameObject enemy = GetClosestEnemy(bullet, _enemiesPool);
            bullet.transform.LookAt(enemy.transform);
            
        }

        private GameObject GetClosestEnemy(GameObject bullet, List<GameObject> enemiesPool)
        {
            
            float previousDistance = Vector3.Distance(enemiesPool[0].transform.position, bullet.transform.position);
            int enemyIndex = 0;
            for (int i = 1; i < enemiesPool.Count; i++)
            {
                float currentDist = Vector3.Distance(enemiesPool[i].transform.position, bullet.transform.position);
                if (currentDist < previousDistance)
                {
                    previousDistance = currentDist;
                    enemyIndex = i;
                }
            }
            return enemiesPool[enemyIndex];
        }
    }
}
