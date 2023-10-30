using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Character.Skills.Enums;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills
{
    public class ProjectileSkill : BaseSkillUsable
    {
        private readonly Transform _shootingSkillPosition;
        private readonly ISpawner<BulletObject> _bulletSpawner;
        
        protected readonly BaseMover Mover;

        public ProjectileSkill(ISpawner<BulletObject> bulletSpawner,Transform shootingSkillPosition, BaseMover mover)
        {
            _bulletSpawner = bulletSpawner;
            _shootingSkillPosition = shootingSkillPosition;
            
            Mover = mover;
        }
        public override void UseSkill()
        {
            Shot(Mover);
        }

        private void Shot(BaseMover mover) //TODO Make one class for enemy and character for shooting
        {
            GameObject bullet =  _bulletSpawner.Spawn("Bullet", Vector3.zero).gameObject;
            
            bullet.transform.position = _shootingSkillPosition.position;
            bullet.transform.rotation = _shootingSkillPosition.rotation;
            
            var bulletObjectManager = bullet.GetComponent<BulletObject>();
            if (bulletObjectManager == null)
            {
                bulletObjectManager = bullet.AddComponent<BulletObject>();
            }
            
            bulletObjectManager.InitBullet(SkillConfig.SkillTypes, mover, SkillConfig.SkillObjectConfig);
        }
    }
}