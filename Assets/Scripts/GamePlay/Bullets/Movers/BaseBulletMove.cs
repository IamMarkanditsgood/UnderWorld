using UnityEngine;

namespace GamePlay.Bullets.Movers
{
    public abstract class BaseBulletMove : IBulletMovable
    {
        public virtual void Move(GameObject bullet, float speed)
        {
            bullet.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}