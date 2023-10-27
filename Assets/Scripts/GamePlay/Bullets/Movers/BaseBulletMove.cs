using UnityEngine;

namespace GamePlay.Bullets.Movers
{
    public abstract class BaseBulletMove
    {
        public virtual void Move(GameObject bullet, float speed)
        {
            bullet.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}