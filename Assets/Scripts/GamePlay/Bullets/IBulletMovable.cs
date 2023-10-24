using UnityEngine;

namespace GamePlay.Bullets
{
    public interface IBulletMovable
    {
        public void Move(GameObject bullet, float speed);
    }
}
