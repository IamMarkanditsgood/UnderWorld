using GamePlay.Entities.Bullets;
using GamePlay.Entities.Bullets.Movers;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.ShootSkills
{
    public class Arrow : ProjectileSkill
    {
        public Arrow(ISpawner<BulletObject> bulletSpawner, Transform shootingSkillPosition) : base(bulletSpawner, shootingSkillPosition, new StandardBullet())
        {
        }
    }
}
