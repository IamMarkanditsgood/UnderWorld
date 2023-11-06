using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Character.Skills;
using GamePlay.Entities.Enemies.EnemySkills;
using GamePlay.Entities.Skills.CharacterSkills;
using UnityEngine;

namespace GamePlay.Entities
{
    public class Shooter
    {
        public void Shot(BaseMover mover, ISpawner<BulletObject> bulletSpawner,Transform shootingSkillPosition, SkillConfig skillConfig) 
        {
            BulletObject bullet =  bulletSpawner.Spawn("Bullet", Vector3.zero);

            var transform = bullet.transform;
            transform.position = shootingSkillPosition.position;
            transform.rotation = shootingSkillPosition.rotation;
            
            /*var bulletObjectManager = bullet.GetComponent<BulletObject>();
            
            if (bulletObjectManager == null)
            {
                bulletObjectManager = bullet.AddComponent<BulletObject>();
            }
            Debug.Log(bulletObjectManager);*/
            bullet.InitBullet(mover, skillConfig.SkillObjectConfig);
        }
    }
}
