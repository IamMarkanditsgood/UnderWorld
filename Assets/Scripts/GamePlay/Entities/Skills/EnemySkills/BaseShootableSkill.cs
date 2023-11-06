using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Enemies.EnemySkills;
using UnityEngine;

namespace GamePlay.Entities.Skills.EnemySkills
{
    public class BaseShootableSkill : EnemyBaseSkill
    {
        private Shooter _shooter = new Shooter();
        private BaseMover _mover;
        private readonly ISpawner<BulletObject> _bulletSpawner;
        private readonly Transform _shootingSkillPosition;

        public BaseShootableSkill(ISpawner<BulletObject> bulletSpawner,Transform shootingSkillPosition)
        {
            _bulletSpawner = bulletSpawner;
            _shootingSkillPosition = shootingSkillPosition;
            
        }

        public virtual void Initialize(BaseMover mover)
        {
            _mover = mover;
        }
        public override void UseSkill()
        {
            _shooter.Shot(_mover, _bulletSpawner, _shootingSkillPosition, SkillConfig);
        }
    }
}