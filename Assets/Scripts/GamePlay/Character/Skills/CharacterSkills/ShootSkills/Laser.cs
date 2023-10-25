using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.ShootSkills
{
    public class Laser : ISkillUsable
    {
        private SkillTypes _skillTypes = SkillTypes.AimRockets;
        

  
        public void UseSkill(GameObject character, SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            //TODO Later 
        }
    }
}
