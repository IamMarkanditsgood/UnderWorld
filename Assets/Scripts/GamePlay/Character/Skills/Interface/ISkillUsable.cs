using GamePlay.Character.Skills.Dictionaries;
using UnityEngine;

namespace GamePlay.Character.Skills.Interface
{
    public interface ISkillUsable
    {
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig);
    }
}
