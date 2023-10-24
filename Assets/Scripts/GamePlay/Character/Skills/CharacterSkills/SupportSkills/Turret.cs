using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.SupportSkills
{
    public class Turret : ISkillUsable
    {
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillsConfig skillConfig)
        {
            ObjectContainer objectContainer = ObjectContainer.InstanceObjectContainer;
            GameObject turret = objectContainer.Turrets.GetFreeElement();
            turret.transform.position = character.transform.position;
        }

    }
}
