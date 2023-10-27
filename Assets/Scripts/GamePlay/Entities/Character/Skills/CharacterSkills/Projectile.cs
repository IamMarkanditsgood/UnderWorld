using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Entities.Bullets;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Entities.Character.Skills.CharacterSkills
{
    public class Projectile : ISkillUsable<Bullet>
    {
        protected SkillTypes _skillTypes;
        protected BaseMover _mover;

        public Projectile(SkillTypes skillTypes, BaseMover mover)
        {
            _skillTypes = skillTypes;
            _mover = mover;
        }
        public virtual void UseSkill(GameObject character,ISpawner<Bullet> spawner,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            Shoot shoot = new Shoot();
            shoot.Shot(character,spawner, _mover, skillConfig);

        }
    }
}