using GamePlay.Entities.Bullets;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.ShootSkills
{
    public class Laser : ProjectileSkill
    {
        public Laser(ISpawner<BulletObject> bulletSpawner, Transform shootingSkillPosition) : base(bulletSpawner, shootingSkillPosition)
        {
        }
    }
}
