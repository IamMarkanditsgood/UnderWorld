using UnityEngine;

namespace GamePlay.Bullets.Movers
{
    public class StandardBullet: IBulletMovable
    {
        public void Move(GameObject bullet, float speed)
        {
            bullet.transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
    }
}
