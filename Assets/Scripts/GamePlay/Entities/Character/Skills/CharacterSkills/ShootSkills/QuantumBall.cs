using GamePlay.Entities.Bullets;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.ShootSkills
{
    public class QuantumBall : ProjectileSkill
    {
        public QuantumBall(ISpawner<BulletObject> bulletSpawner, Transform shootingSkillPosition) : base(bulletSpawner, shootingSkillPosition)
        {
        }
    }
}
