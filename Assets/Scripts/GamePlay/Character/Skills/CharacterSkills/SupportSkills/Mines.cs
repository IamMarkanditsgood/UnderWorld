using System.Threading;
using System.Threading.Tasks;
using GamePlay.Character.Skills.Dictionaries;
using GamePlay.Character.Skills.Interface;
using GamePlay.Level;
using UnityEngine;

namespace GamePlay.Character.Skills.CharacterSkills.SupportSkills
{
    public class Mines : ISkillUsable
    {
        public void UseSkill(GameObject character,SkillDictionaries skillDictionaries, SkillConfig skillConfig)
        {
            ObjectContainer objectContainer = ObjectContainer.InstanceObjectContainer;
            GameObject mine = objectContainer.Mines.GetFreeElement();
            mine.transform.position = character.transform.position;
        }

    }
}
