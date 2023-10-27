using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.ShootSkills
{
    public class Fireball : ISkillUsable
    {
        private SkillTypes _skillTypes = SkillTypes.Fireball;
        private BaseMover _mover = new StandardBullet();
        
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            Shoot shoot = new Shoot();
            shoot.Shot(character, _mover, _skillTypes, skillConfig);

        }
    }
}
