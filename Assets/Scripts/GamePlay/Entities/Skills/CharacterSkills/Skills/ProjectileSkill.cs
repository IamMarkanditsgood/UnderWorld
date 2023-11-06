using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Character.Skills.Enums;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills
{
    public class ProjectileSkill : BaseSkillUsable
    {
        private readonly Shooter _shooter = new Shooter();
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
            _shooter.Shot(Mover, _bulletSpawner, _shootingSkillPosition, SkillConfig);
        }
    }
}