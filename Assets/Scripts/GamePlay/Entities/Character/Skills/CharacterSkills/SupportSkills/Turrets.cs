using GamePlay.Character.Skills;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Entities.Turrets;
using GamePlay.Level;
using UnityEngine;
using Zenject;

namespace GamePlay.Entities.Character.Skills.CharacterSkills.SupportSkills
{
    public class Turrets : ISkillUsable<Turret>
    {
        private ISpawner<Turret> _turret;

        public void UseSkill(GameObject character, ISpawner<Turret> spawner,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            GameObject turret = _turret.Spawn("Turret", Vector3.zero).gameObject;
            turret.transform.position = character.transform.position;
        }
        
    }
}
