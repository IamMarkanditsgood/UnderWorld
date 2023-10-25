using System.Collections;
using System.Collections.Generic;
using GamePlay.Bullets;
using GamePlay.Bullets.Movers;
using GamePlay.Character;
using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

public class Fireball : ISkillUsable
{
    private SkillTypes _skillTypes = SkillTypes.Fireball;
    private IBulletMovable _mover = new StandardBullet();
        
    public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
    {
        Shoot shoot = new Shoot();
        shoot.Shot(character, _mover, _skillTypes, skillConfig);

    }
}
