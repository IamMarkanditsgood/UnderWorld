using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using GamePlay.Entities.Skills.EnemySkills;
using UnityEngine;

namespace GamePlay.Entities.Enemies.EnemySkills.Skills
{
    public class MagicShoot: BaseShootableSkill
    {
        private readonly BaseMover _mover = new StandardBullet();
        public MagicShoot(ISpawner<BulletObject> bulletSpawner, Transform shootingSkillPosition) : base(bulletSpawner,shootingSkillPosition)
        {
            base.Initialize(_mover);
        }
    }
}