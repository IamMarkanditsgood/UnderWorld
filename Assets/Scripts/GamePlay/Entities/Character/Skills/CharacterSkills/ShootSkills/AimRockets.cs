using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.ShootSkills
{
    public class AimRockets : Projectile
    {
        public AimRockets(SkillTypes skillTypes, BaseMover mover) : base(skillTypes, mover)
        {
        }
    }
}

