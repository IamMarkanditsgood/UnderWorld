using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.ShootSkills
{
    public class AimRockets : ISkillUsable
    {
        private SkillTypes _skillTypes = SkillTypes.AimRockets;
        private IBulletMovable _mover = new AimedBullet();
        
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            Shoot shoot = new Shoot();
            shoot.Shot(character, _mover, _skillTypes, skillConfig);

        }
    }
}

