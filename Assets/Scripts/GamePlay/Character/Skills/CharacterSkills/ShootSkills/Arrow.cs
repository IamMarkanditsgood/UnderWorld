using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEditor;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.ShootSkills
{
    public class Arrow : ISkillUsable
    {
        private SkillTypes _skillTypes = SkillTypes.Arrow;
        private IBulletMovable _mover = new StandardBullet();
        
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            Shoot shoot = new Shoot();
            shoot.Shot(character, _mover, _skillTypes, skillConfig);
        }
    }
}
