using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Bullets
{
    public class Shoot
    {
        public void Shot(GameObject character, BaseMover mover,SkillTypes skillTypes, SkillConfig skillConfig )
        {
            ObjectContainer objectContainer = ObjectContainer.InstanceObjectContainer;
            Transform bulletPos = character.GetComponent<Character.Character>().ShootingSkillPos;
            
            GameObject bullet = objectContainer.Bullets.GetFreeElement();
            bullet.transform.position = bulletPos.position;
            bullet.transform.rotation = bulletPos.rotation;
            
            Bullet bulletManager = bullet.GetComponent<Bullet>();
            if (bulletManager == null)
            {
                bulletManager =  bullet.AddComponent<Bullet>();
            }
            
            bulletManager.InitBullet(skillTypes, mover, skillConfig.SkillObjectConfig);
        }
    }
}
