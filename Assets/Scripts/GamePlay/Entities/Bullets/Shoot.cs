using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Interface;
using GamePlay.Entities.Bullets;
using GamePlay.Entities.Enemy;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Bullets
{
    public class Shoot
    {

        public void Shot(GameObject character,ISpawner<Bullet> spawner, BaseMover mover, SkillConfig skillConfig )
        {
            Transform bulletPos = character.GetComponent<Character.Character>().ShootingSkillPos;
            
            GameObject bullet =  spawner.Spawn("Bullet", Vector3.zero).gameObject;
            
            bullet.transform.position = bulletPos.position;
            bullet.transform.rotation = bulletPos.rotation;
            
            Bullet bulletManager = bullet.GetComponent<Bullet>();
            if (bulletManager == null)
            {
                bulletManager =  bullet.AddComponent<Bullet>();
            }
            
            bulletManager.InitBullet(skillConfig.SkillTypes, mover, skillConfig.SkillObjectConfig);
        }
    }
}
