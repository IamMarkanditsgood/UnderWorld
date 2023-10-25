using UnityEngine;

namespace GamePlay.Bullets.Movers
{
    public abstract class BaseMover
    {
        public virtual void Move(GameObject bullet, float speed)
        {
            bullet.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}